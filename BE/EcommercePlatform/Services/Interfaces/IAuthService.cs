using EcommercePlatform.DTOs.RequestDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO registerDTO);
    }
}
