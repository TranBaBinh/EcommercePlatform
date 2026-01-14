using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using EcommercePlatform.Services.Interfaces;

namespace EcommercePlatform.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryrepo;

        public CategoryService(ICategoryRepository categoryrepo)
        {
            _categoryrepo = categoryrepo;
        }

        public async Task<CategoryDTO> AddCategoryAsync(CreateCategoryDTO categoryDTO)
        {
            var obj = new Category
            {
                Id = Guid.NewGuid(),
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                ParentCategoryId = categoryDTO.ParentCategoryId
            };
            await _categoryrepo.AddCategory(obj);
            return new CategoryDTO
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                ParentCategoryId = obj.ParentCategoryId
            };
        }
    }
}
