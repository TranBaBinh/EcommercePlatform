using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);

        Task UpdateUserAsync(User user);

        Task AddUserAsync(User user);

        Task AddRefeshTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetRefreshTokenAsync(string token);

        Task SaveChangesAsync();
    }
}
