using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO registerDTO);

        Task<string> GenerateTokenVerifyEmailAsync(Guid userId);

        Task<VerifyResponseDTO> VerifyEmailAsync(Guid userId , string Token);

        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);

        Task SendPasswordResetByEmailAsync(string email);

        Task<bool> ResetPasswordAsync(string token , string newPassword , string confirmPassword);

        Task<LoginResponseDTO> RefreshTokenAsync(string Token);
    }
}
