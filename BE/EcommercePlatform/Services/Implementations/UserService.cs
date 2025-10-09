using EcommercePlatform.DTOs.RequestDTO;
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

        public async Task<UpdateUserProfileDTO?> UpdateUserProfileAsync(Guid id, UpdateUserProfileDTO userProfileDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            if (!string.IsNullOrWhiteSpace(userProfileDTO.FullName))
            {
                user.FullName = userProfileDTO.FullName;
            }
            if (!string.IsNullOrWhiteSpace(userProfileDTO.Phone))
            {
                user.PhoneNumber = userProfileDTO.Phone;
            }
            if (!string.IsNullOrWhiteSpace(userProfileDTO.Gender))
            {
                user.Gender = userProfileDTO.Gender;
            }
            if (!string.IsNullOrWhiteSpace(userProfileDTO.AvatarUrl))
            {
                user.AvatarUrl = userProfileDTO.AvatarUrl;
            }

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return new UpdateUserProfileDTO
            {
                FullName = user.FullName,
                Phone = user.PhoneNumber,
                Gender = user.Gender,
                AvatarUrl = user.AvatarUrl
            };

        }
    }
}
