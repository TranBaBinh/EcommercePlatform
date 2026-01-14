using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    { 
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
