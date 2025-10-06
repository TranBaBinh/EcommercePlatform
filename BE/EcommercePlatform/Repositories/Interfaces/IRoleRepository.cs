using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IRoleRepository
    {
       Task<Role> GetByName(string RoleName);
    }
}
