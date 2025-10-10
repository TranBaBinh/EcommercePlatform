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

        public async Task<bool> ChangePasswordAsync(Guid id , ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) throw new Exception("User không tìm thấy");
            if (!BCrypt.Net.BCrypt.Verify(changePasswordDTO.CurrentPassword, user.PasswordHash))
                throw new Exception("Mật khẩu không chính xác");
            if (changePasswordDTO.NewPassword != changePasswordDTO.ConfirmNewPassword)
                throw new Exception("Mật khẩu không khớp");
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePasswordDTO.NewPassword);
            await _userRepository.SaveChangesAsync();
            return true;
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

        public async Task<UpdateUserProfileDTO?> UpdateAvatarUserAsync(Guid id, string urlImage)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if(user == null) return null;
            user.AvatarUrl = urlImage;
            await _userRepository.SaveChangesAsync();
            return new UpdateUserProfileDTO
            {
                FullName= user.FullName,
                AvatarUrl= user.AvatarUrl,
                Gender = user.Gender,
                Phone =  user.PhoneNumber
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
