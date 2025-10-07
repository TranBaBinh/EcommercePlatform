using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using EcommercePlatform.Services.CommonService;
using EcommercePlatform.Services.Interfaces;

namespace EcommercePlatform.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IEmailVfRepository _emailVfRepo;
        private readonly EmailService _emailService;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IEmailVfRepository emailVfRepo, EmailService emailService, IJwtService jwtService)
        {
            _userRepo = userRepository;
            _roleRepo = roleRepository;
            _emailVfRepo = emailVfRepo;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<string> GenerateTokenVerifyEmailAsync(Guid userId)
        {
            string token = Guid.NewGuid().ToString();

            var obj = new EmailVerificationToken
            {
                UserId = userId,
                Token = token,
                ExpiresAt = DateTime.Now.AddMinutes(5)
            };
            await _emailVfRepo.AddEmailToken(obj);
            await _emailVfRepo.SaveChangesAsync();
            return token;
        }

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            var exitingUser = await _userRepo.GetByEmailAsync(registerDTO.Email);
            if (exitingUser != null)
            {
                throw new Exception("Email already exists!");
            }
            if (registerDTO.Password != registerDTO.PasswordConfirmed)
            {
                throw new Exception("Passwords do not match!");
            }
            var defaultRole = await _roleRepo.GetByName("User");
            if (defaultRole == null)
            {
                throw new Exception("Default role 'User' not found!");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            var user = new User
            {
                FullName = registerDTO.FullName,
                Email = registerDTO.Email,
                PasswordHash = passwordHash,
                RoleId = defaultRole.Id,
            };
            await _userRepo.AddUserAsync(user);
            await _userRepo.SaveChangesAsync();

            string token = await GenerateTokenVerifyEmailAsync(user.Id);

            string verifyLink = GenerateVerificationLink(user.Id, token);

            string body = $@"
        <h3>Welcome to Ecommerce Platform!</h3>
        <p>Please verify your email by clicking the button below:</p>
        <a href='{verifyLink}' style='display:inline-block; padding:10px 20px; background-color:#4CAF50; color:white; text-decoration:none;'>Verify Email</a>
        <p>If the button doesn't work, copy and paste this link into your browser:</p>
        <p>{verifyLink}</p>
    ";
            await _emailService.SendEmailAsync(user.Email, "Verify your email", body);


        }

        public string GenerateVerificationLink(Guid userId, string token)
        {
            return $"https://localhost:7165/api/auth/verify-email?userId={userId}&token={token}";
        }


        public async Task<VerifyEmailResponseDTO> VerifyEmailAsync(Guid userId, string Token)
        {
            var emailToken = await _emailVfRepo.GetByToken(Token);
            if (emailToken == null || emailToken.UserId != userId)
            {

                return new VerifyEmailResponseDTO
                {
                    Success = false,
                    Message = "Token khong hop le"
                };
            }
            if (emailToken.ExpiresAt < DateTime.Now)
            {
                return new VerifyEmailResponseDTO
                {
                    Success = false,
                    Message = "Token het han"
                };
            }
            var user = await _userRepo.GetUserByIdAsync(userId);
            if (user == null)
            {
                return new VerifyEmailResponseDTO
                {
                    Success = false,
                    Message = "Nguoi dung khong ton tai"
                };
            }
            user.IsActive = true;
            await _userRepo.SaveChangesAsync();

            emailToken.ExpiresAt = DateTime.Now;
            await _emailVfRepo.SaveChangesAsync();

            return new VerifyEmailResponseDTO
            {
                Success = true,
                Message = "Xac thuc email thanh cong"
            };
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userRepo.GetByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                return new LoginResponseDTO
                {
                    Success = false,
                    Message = "Email khong ton tai"
                };
            }
            if (!user.IsActive)
            {
                return new LoginResponseDTO
                {
                    Success = false,
                    Message = "Tai khoan chua duoc xac minh"
                };
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return new LoginResponseDTO { Success = false, Message = "Sai mật khẩu." };
            }
            string accessToken = _jwtService.GenerateAccessToken(user);
            string refreshToken = _jwtService.GenerateRefreshToken();
            var newToken = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiresAt = DateTime.Now.AddDays(30)
            };
            await _userRepo.AddRefeshTokenAsync(newToken);
            await _userRepo.SaveChangesAsync();
            return new LoginResponseDTO
            {
                Success = true,
                Message = "Đăng nhập thành công",
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<LoginResponseDTO> RefreshTokenAsync(string Token)
        {
            var exitingToken = await _userRepo.GetRefreshTokenAsync(Token);

            if (exitingToken == null || exitingToken.IsRevoked == true || exitingToken.ExpiresAt < DateTime.Now)
            {
                return new LoginResponseDTO
                {
                    Success = false,
                    Message = "Refresh token không hợp lệ"
                };
            }
            var user = exitingToken.user;
            var newAccessToken = _jwtService.GenerateAccessToken(user);
            var newToken = _jwtService.GenerateRefreshToken();
            var newRefreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = newToken,
                ExpiresAt = DateTime.Now.AddDays(30)
            };
            exitingToken.IsRevoked = true;
            await _userRepo.AddRefeshTokenAsync(newRefreshToken);
            await _userRepo.SaveChangesAsync();
            return new LoginResponseDTO
            {
                Success = true,
                Message = "Cấp lại access token thành công",
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }
    }
}
