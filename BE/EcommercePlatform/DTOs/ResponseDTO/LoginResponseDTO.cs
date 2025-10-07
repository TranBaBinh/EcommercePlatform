using Azure.Core;

namespace EcommercePlatform.DTOs.ResponseDTO
{
    public class LoginResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }
    }
}
