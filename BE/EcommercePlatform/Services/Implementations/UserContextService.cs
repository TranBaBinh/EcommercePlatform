using EcommercePlatform.Services.Interfaces;
using System.Security.Claims;

namespace EcommercePlatform.Services.Implementations
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public ClaimsPrincipal? User => _httpContextAccessor.HttpContext?.User;
        public Guid? UserId
        {
            get
            {
                var idClaim = User?.FindFirst(ClaimTypes.NameIdentifier)
                              ?? User?.FindFirst("sub")
                              ?? User?.FindFirst("Id");

                if (idClaim != null && Guid.TryParse(idClaim.Value, out var userId))
                {
                    return userId;
                }
                return null;
            }
        }

        public Guid GetUserId()
        {
            var userId = UserId;
            if (userId == null)
            {
                throw new UnauthorizedAccessException("Bạn chưa đăng nhập hoặc Token không hợp lệ.");
            }
            return userId.Value;
        }

        public string? Email => User?.FindFirst(ClaimTypes.Email)?.Value;

        public string? Role => User?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
