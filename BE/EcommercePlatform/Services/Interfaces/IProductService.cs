using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Repositories.Interfaces;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync (CreateProductDTO createProductDTO);
        Task<PaginatedResult<ProductDTO>> GetAllProductsAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize);
        Task<ProductDTO?> GetProductByIdAsync(Guid id);
        Task<ProductDTO> UpdateProductAsync(Guid id, UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
