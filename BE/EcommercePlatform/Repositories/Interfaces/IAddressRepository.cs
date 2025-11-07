using EcommercePlatform.Entities;

namespace EcommercePlatform.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task <IEnumerable<Address>> GetAddressByUserId (Guid userId);
        Task <Address?> GetAddressById (Guid id);

        Task AddAddress(Address address);
        Task UpdateAddress (Address address);
        Task SoftDeleteAddressAsync(Address address);
        Task RemoveDefaultAddressAsync(Guid userId);
        Task SaveChangesAsync();
    }
}
