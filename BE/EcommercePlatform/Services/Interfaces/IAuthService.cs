using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO registerDTO);

        Task<string> GenerateTokenVerifyEmailAsync(Guid userId);

        Task<VerifyEmailResponseDTO> VerifyEmailAsync(Guid userId , string Token);
    }
}
