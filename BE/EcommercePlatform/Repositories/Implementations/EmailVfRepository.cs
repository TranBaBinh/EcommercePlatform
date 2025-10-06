using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class EmailVfRepository : IEmailVfRepository
    {   
        private readonly AppDbContext _context;

        public EmailVfRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddEmailToken(EmailVerificationToken token)
        {
            await _context.EmailVerificationTokens.AddAsync(token);
        }

        public async Task<EmailVerificationToken?> GetByToken(string token)
        {
            return await _context.EmailVerificationTokens.FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
