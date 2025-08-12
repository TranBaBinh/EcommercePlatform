using EcommercePlatform.Repositories.Interfaces;
using EcommercePlatform.Services.Interfaces;

namespace EcommercePlatform.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task RegisterAsync(string email, string password, string fullname)
        {
            throw new NotImplementedException();
        }
    }
}
