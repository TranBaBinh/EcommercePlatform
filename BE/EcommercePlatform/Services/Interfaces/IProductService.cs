using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Repositories.Interfaces;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync (CreateProductDTO createProductDTO);
        Task<List<ProductDTO>> GetAllProductsAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize);
        Task<ProductDTO?> GetProductByIdAsync(Guid id);
    }
}
