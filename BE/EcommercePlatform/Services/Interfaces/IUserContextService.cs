namespace EcommercePlatform.Services.Interfaces
{
    public interface IUserContextService
    {
     
        Guid? UserId { get; }  
        Guid GetUserId();
        string? Email { get; }
        string? Role { get; }
    }
}
