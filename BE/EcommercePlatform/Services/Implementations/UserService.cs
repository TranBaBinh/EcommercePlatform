using EcommercePlatform.DTOs.ResponseDTO;
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

        public async Task<UserProfileDTO?> GetUserProfileAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            return new UserProfileDTO
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                AvatarUrl = user.AvatarUrl,
                RoleName = user.UserRole?.Name
            };
        }

    }
}
