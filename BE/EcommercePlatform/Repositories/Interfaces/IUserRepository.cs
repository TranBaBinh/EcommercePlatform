using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetUserByIdAsync(Guid id);
        Task AddUserAsync(User user);
        Task SaveChangesAsync();
    }
}
