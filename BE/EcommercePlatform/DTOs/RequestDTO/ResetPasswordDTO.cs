namespace EcommercePlatform.DTOs.RequestDTO
{
    public class ResetPasswordDTO
    {
        public string Token { get; set; }
        public string Newpassword { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
