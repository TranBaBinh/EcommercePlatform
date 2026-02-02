using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using EcommercePlatform.Services.Interfaces;

namespace EcommercePlatform.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUserContextService _userContextService;
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryService _cloudinaryService;

        public ProductService(IUserContextService userContextService, IProductRepository productRepository, ICloudinaryService cloudinaryService)
        {
            _userContextService = userContextService;
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                StockQuantity = createProductDTO.StockQuantity,
                CategoryId = createProductDTO.CategoryId,
                SellerId = _userContextService.GetUserId(),
                CreatedAt = DateTime.Now,
                IsActive = true,
            };
            if (createProductDTO.ImagesUrl != null && createProductDTO.ImagesUrl.Any())
            {
                foreach (var image in createProductDTO.ImagesUrl)
                {
                    string urlImage = await _cloudinaryService.UploadImageAsync(image, "productimage");
                    if (urlImage != null)
                    {
                        product.ProductImages.Add(new ProductImage
                        {
                            ImageUrl = urlImage,
                            IsThumbnail = product.ProductImages.Count == 0
                        });
                    }

                }
            }
            await _productRepository.AddProductAsync(product);
            return MapToDTO(product);
        }

        private ProductDTO MapToDTO(Product product)
        {
            var now = DateTime.Now;
            var activePromo = product.ProductPromotions.Select(pp => pp.Promotion)
                                                        .Where(prom => prom.IsActive && prom.StartDate <= now && prom.EndDate >= now)
                                                        .OrderByDescending(prom => prom.DiscountPercent)
                                                        .FirstOrDefault();
            decimal priceOfProduct = product.Price;
            decimal discountPercent = 0;
            string? promotionName = null;
            if (activePromo != null)
            {
                discountPercent = activePromo.DiscountPercent;
                promotionName = activePromo.Name;
                priceOfProduct = product.Price * (1 - discountPercent / 100);
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                StockQuantity = product.StockQuantity,
                Price = product.Price,
                CurrentPrice = priceOfProduct,
                DiscountPercent = discountPercent,
                PromotionName = promotionName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name ?? "N/A",
                SellerName = product.Seller?.FullName ?? "N/A",
                ThumbnailUrl = product.ProductImages.FirstOrDefault(x => x.IsThumbnail)?.ImageUrl
                               ?? product.ProductImages.FirstOrDefault()?.ImageUrl,

                ImageUrls = product.ProductImages.Select(x => x.ImageUrl).ToList()

            };
        }

        public Task<List<ProductDTO>> GetAllProductsAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
