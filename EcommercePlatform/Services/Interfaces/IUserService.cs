namespace EcommercePlatform.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string fullname);
    }
}
