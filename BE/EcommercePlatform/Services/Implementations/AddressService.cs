using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using EcommercePlatform.Services.Interfaces;

namespace EcommercePlatform.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressDTO> AddAddressAsync(Guid userId, AddressDTO addressDTO)
        {
            if (addressDTO.IsDefault)
            {
                await _addressRepository.RemoveDefaultAddressAsync(userId);
            }

            var newAddress = new Address
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Street = addressDTO.Street,
                City = addressDTO.City,
                District = addressDTO.District,
                Ward = addressDTO.Ward,
                IsDefault = addressDTO.IsDefault,
                IsDeleted = false
            };

            await _addressRepository.AddAddress(newAddress);
            await _addressRepository.SaveChangesAsync();

            return new AddressDTO
            {
                Id = newAddress.Id,
                Street = newAddress.Street,
                City = newAddress.City,
                District = newAddress.District,
                Ward = newAddress.Ward,
                IsDefault = newAddress.IsDefault
            };
        }

        public async Task<bool> DeleteAddressAsync(Guid userId, Guid addressId)
        {
            var address = await _addressRepository.GetAddressById(addressId);
            if(address == null || address.UserId != userId)
            {
                return false;
            }
            address.IsDeleted = true;
            await _addressRepository.UpdateAddress(address);
            await _addressRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AddressDTO>> GetAddressesAsync(Guid userId)
        {
            var ob = await _addressRepository.GetAddressByUserId(userId);
            if (ob == null)
            {
                return null;
            }
            return ob.Where(a => !a.IsDeleted)
                .Select(a => new AddressDTO
            {
                Id = a.Id,
                Street = a.Street,
                City = a.City,
                District = a.District,
                Ward = a.Ward,
                IsDefault = a.IsDefault,
            });
        }

        public async Task<AddressDTO?> UpdateAddressAsync(Guid userId, AddressDTO addressDTO)
        {
            var exitsAddress = await _addressRepository.GetAddressById(addressDTO.Id);
            if (exitsAddress == null || userId != exitsAddress.UserId) {
                return null;
            }
            if (addressDTO.IsDefault)
                await _addressRepository.RemoveDefaultAddressAsync(userId);
            exitsAddress.Street = addressDTO.Street;
            exitsAddress.City = addressDTO.City;
            exitsAddress.District = addressDTO.District;
            exitsAddress.Ward = addressDTO.Ward;
            exitsAddress.IsDefault = addressDTO.IsDefault;

            await _addressRepository.UpdateAddress(exitsAddress);
            await _addressRepository.SaveChangesAsync();

            return addressDTO;
        }
    }
}
