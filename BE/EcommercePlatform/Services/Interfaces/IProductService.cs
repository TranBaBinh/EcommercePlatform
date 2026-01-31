using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Repositories.Interfaces;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> CreateProductAsync (CreateProductDTO createProductDTO);



    }
}
