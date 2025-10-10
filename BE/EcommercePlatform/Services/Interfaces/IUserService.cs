using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IUserService
    {      
        Task<UserProfileDTO?> GetUserProfileAsync(Guid id);

        Task<UpdateUserProfileDTO?> UpdateUserProfileAsync(Guid id , UpdateUserProfileDTO userProfileDTO);

        Task<bool> ChangePasswordAsync(Guid id , ChangePasswordDTO changePasswordDTO);

        Task<UpdateUserProfileDTO?> UpdateAvatarUserAsync(Guid id, string urlImage);
    }
}
