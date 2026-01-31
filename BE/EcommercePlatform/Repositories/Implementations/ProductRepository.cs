using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize)
        {
            var query = _context.Products.Include(p => p.ProductImages)
                                         .Include(p => p.Category)
                                         .Include(p => p.ProductPromotions)
                                         .ThenInclude(p => p.Promotion)
                                         .AsQueryable();
            if (!string.IsNullOrEmpty(keyword)) {
                query = query.Where(p => p.Name.Contains(keyword) || (p.Description != null && p.Description.Contains(keyword)));
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            return await query
                .OrderByDescending(p => p.CreatedAt) 
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
           return await _context.Products.Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Include(p => p.Seller)
                .Include(p => p.ProductPromotions)
                .ThenInclude(pp => pp.Promotion)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
