using EcommercePlatform.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommercePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet("profile-user")]
        public async Task<IActionResult> GetProfileUser() {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) {
                return Unauthorized(new { message = "Invalid Token"});
            }
            var userId = Guid.Parse(userIdClaim);

            var userProfile =await _userService.GetUserProfileAsync(userId);
            if (userProfile == null) {
                return NotFound(new {message = "User not found " });
            }
            return Ok(userProfile);
        }
    }
}
