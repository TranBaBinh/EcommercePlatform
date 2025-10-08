using EcommercePlatform.DTOs.ResponseDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IUserService
    {      
        Task<UserProfileDTO?> GetUserProfileAsync(Guid id);
    }
}
