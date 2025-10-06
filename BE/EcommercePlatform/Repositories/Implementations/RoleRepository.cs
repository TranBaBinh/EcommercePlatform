using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Role?> GetByName(string RoleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(RoleName));
        }
    }
}
