using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IPasswordResetRepository
    {
        Task AddPassResetToken(PasswordResetToken token);
        Task<PasswordResetToken?> GetByToken(string token);

        Task SaveChangesAsync();
    }
}
