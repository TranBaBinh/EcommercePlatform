using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        Task AddCategory(Category category);

    }
}
