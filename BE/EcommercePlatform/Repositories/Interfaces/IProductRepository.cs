using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);

        Task<List<Product>> GetAllAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize);

        Task<Product?> GetByIdAsync(Guid id);

        Task UpdateProductAsync(Product product);
    }
}
