using EcommercePlatform.Data;
using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRefeshTokenAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _context.Users
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
            return await _context.RefreshTokens
    .Include(r => r.user)
    .ThenInclude(u => u.UserRole)
    .FirstOrDefaultAsync(r => r.Token == token);

        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
