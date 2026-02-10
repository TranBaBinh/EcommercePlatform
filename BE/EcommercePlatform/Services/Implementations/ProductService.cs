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

        public async Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize)
        {
            var products = await _productRepository.GetAllAsync(keyword, categoryId, pageIndex, pageSize);
            var totalCount = await _productRepository.GetTotalCountAsync(keyword, categoryId);

            return new PaginatedResult<ProductDTO>
            {
                Items = products.Select(MapToDTO).ToList(),
                TotalCount = totalCount,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product == null ? null : MapToDTO(product);
        }

        public async Task<ProductDTO> UpdateProductAsync(Guid id, UpdateProductDTO updateProductDTO)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new Exception($"Product with ID {id} not found");

            // Verify seller (chỉ seller của product mới được update)
            var currentUserId = _userContextService.GetUserId();
            if (product.SellerId != currentUserId)
                throw new UnauthorizedAccessException("You are not authorized to update this product");

            // Update basic info
            product.Name = updateProductDTO.Name;
            product.Description = updateProductDTO.Description;
            product.Price = updateProductDTO.Price;
            product.StockQuantity = updateProductDTO.StockQuantity;
            product.CategoryId = updateProductDTO.CategoryId;
            product.IsActive = updateProductDTO.IsActive;

            // Handle images update
            if (updateProductDTO.ExistingImageUrls != null)
            {
                // Xóa các ảnh không còn trong danh sách ExistingImageUrls
                var imagesToRemove = product.ProductImages
                    .Where(img => !updateProductDTO.ExistingImageUrls.Contains(img.ImageUrl))
                    .ToList();

                foreach (var img in imagesToRemove)
                {
                    product.ProductImages.Remove(img);
                }
            }
            else
            {
                // Nếu không có ExistingImageUrls, xóa tất cả ảnh cũ
                product.ProductImages.Clear();
            }

            // Thêm ảnh mới
            if (updateProductDTO.NewImages != null && updateProductDTO.NewImages.Any())
            {
                foreach (var image in updateProductDTO.NewImages)
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

            // Set thumbnail nếu chưa có
            if (product.ProductImages.Any() && !product.ProductImages.Any(img => img.IsThumbnail))
            {
                product.ProductImages.First().IsThumbnail = true;
            }

            await _productRepository.UpdateProductAsync(product);

            // Reload product với relationships
            var updatedProduct = await _productRepository.GetByIdAsync(id);
            return MapToDTO(updatedProduct!);
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new Exception($"Product with ID {id} not found");

            // Verify seller
            var currentUserId = _userContextService.GetUserId();
            if (product.SellerId != currentUserId)
                throw new UnauthorizedAccessException("You are not authorized to delete this product");

            await _productRepository.DeleteProductAsync(product);
            return true;
        }
    }
}
