namespace EcommercePlatform.DTOs.RequestDTO
{
    public class RegisterDTO
    {
        public string FullName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
    }
}
