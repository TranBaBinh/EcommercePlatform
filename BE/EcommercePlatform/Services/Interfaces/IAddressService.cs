using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;

namespace EcommercePlatform.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDTO>> GetAddressesAsync(Guid userId);

        Task<AddressDTO> AddAddressAsync(Guid userId, AddressDTO addressDTO);

        Task<AddressDTO?> UpdateAddressAsync(Guid userId, AddressDTO addressDTO);
        Task<bool> DeleteAddressAsync(Guid userId, Guid addressId);
    }
}
