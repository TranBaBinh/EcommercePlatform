using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly AppDbContext _context;
        public PasswordResetRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddPassResetToken(PasswordResetToken token)
        {
            await _context.PasswordResetTokens.AddAsync(token);
        }

        public async Task<PasswordResetToken?> GetByToken(string token)
        {
            return await _context.PasswordResetTokens
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Token == token);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
