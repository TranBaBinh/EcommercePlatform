using EcommercePlatform.Entities;
using System.Security.Claims;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
