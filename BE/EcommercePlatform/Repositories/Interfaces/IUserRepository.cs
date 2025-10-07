using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);

        Task AddRefeshTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetRefreshTokenAsync(string token);

        Task SaveChangesAsync();
    }
}
