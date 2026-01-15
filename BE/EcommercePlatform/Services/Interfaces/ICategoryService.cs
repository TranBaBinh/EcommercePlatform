using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategoryAsync(CreateCategoryDTO categoryDTO);

        Task<List<CategoryDTO>> GetListCategory(); 
    }
}
