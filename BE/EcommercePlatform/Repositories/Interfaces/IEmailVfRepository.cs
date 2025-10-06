using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IEmailVfRepository
    {
        Task AddEmailToken(EmailVerificationToken token);
        Task<EmailVerificationToken?> GetByToken(string token);

        Task SaveChangesAsync();

    }
}
