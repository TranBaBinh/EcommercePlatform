using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommercePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                await _authService.RegisterAsync(registerDTO);
                return Ok(new { message = "Registration successful. Check your email to verify account."});
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] Guid userId , [FromQuery] string token)
        {
            
              var rs =  await _authService.VerifyEmailAsync(userId , token);
            if (rs.Success == true)
            {
                return Ok(rs);
            }
            return BadRequest(rs);
             
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {

            var rs = await _authService.LoginAsync(loginDTO);
            if (rs.Success == true)
            {
                return Ok(rs);
            }
            return BadRequest(rs);

        }
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {

            var rs = await _authService.RefreshTokenAsync(token);
            if (rs.Success == true)
            {
                return Ok(rs);
            }
            return BadRequest(rs);

        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {

            try
            {
                await _authService.SendPasswordResetByEmailAsync(email);
                return Ok(new { Message = "Email reset password đã được gửi" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {

            try
            {
                var rs = await _authService.ResetPasswordAsync(
                    resetPasswordDTO.Token,
                    resetPasswordDTO.Newpassword,
                    resetPasswordDTO.ConfirmPassword
                );

                if (!rs)
                    return BadRequest(new { Message = "Đặt lại mật khẩu thất bại" });

                return Ok(new { Message = "Đặt lại mật khẩu thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
