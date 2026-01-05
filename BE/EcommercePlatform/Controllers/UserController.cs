using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Services.CommonService;
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
        private readonly ICloudinaryService _cloudinaryService;
        public UserController(IUserService userService, ICloudinaryService cloudinaryService)
        {
            _userService = userService;
            _cloudinaryService = cloudinaryService;
        }
        [HttpGet("profile-user")]
        public async Task<IActionResult> GetProfileUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Invalid Token" });
            }
            var userId = Guid.Parse(userIdClaim);

            var userProfile = await _userService.GetUserProfileAsync(userId);
            if (userProfile == null)
            {
                return NotFound(new { message = "User not found " });
            }
            return Ok(userProfile);
        }
        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfileUser([FromBody] UpdateUserProfileDTO updateUserProfileDTO)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Invalid Token" });
            }
            var userId = Guid.Parse(userIdClaim);

            var obj = await _userService.UpdateUserProfileAsync(userId, updateUserProfileDTO);
            if (obj == null) return NotFound(new { message = "update không thành công" });
            return Ok(obj);
        }
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Invalid Token" });
            }
            var userId = Guid.Parse(userIdClaim);
            bool rs = await _userService.ChangePasswordAsync(userId, changePasswordDTO);
            return Ok(rs);
        }
        [HttpPut("upload-avatar")]
        public async Task<IActionResult> UploadAvatar([FromForm] UploadAvatarDTO formFile)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized(new { message = "Invalid Token" });
            }
            var userId = Guid.Parse(userIdClaim);
            var imageUrl = await _cloudinaryService.UploadImageAsync(formFile.Avatar, "avatars");
            var updateAvatar = await _userService.UpdateAvatarUserAsync(userId, imageUrl);
            if (updateAvatar != null)
            {
                return Ok(updateAvatar);
            }
            else
            {
                return BadRequest("Update avatar không thành công");
            }
        }
    }
}
