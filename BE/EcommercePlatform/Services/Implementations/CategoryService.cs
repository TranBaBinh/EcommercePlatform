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

        public async Task<List<CategoryDTO>> GetListCategory()
        {
            var allCate = await _categoryrepo.GetAllCategoryAsync();

            var rootCate = allCate.Where(c => c.ParentCategoryId == null).ToList();

            var rs = rootCate.Select(c => MapToDtoRecursively(c, rootCate)).ToList();

            return rs;
        }

        private CategoryDTO MapToDtoRecursively(Category category, IEnumerable<Category> allCategories)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ParentCategoryId = category.ParentCategoryId,
                SubCategories = allCategories
                    .Where(c => c.ParentCategoryId == category.Id) 
                    .Select(child => MapToDtoRecursively(child, allCategories)) 
                    .ToList()
            };
        }
    }
}
