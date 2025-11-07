using EcommercePlatform.Data;
using EcommercePlatform.Entities;
using EcommercePlatform.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommercePlatform.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAddress(Address address)
        {
            await _context.Addresses.AddAsync(address);
        }

        public async Task<Address?> GetAddressById(Guid id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Address>> GetAddressByUserId(Guid userId)
        {
            return await _context.Addresses
               .Where(a => a.UserId == userId && !a.IsDeleted)
               .ToListAsync();
        }
        public async Task SoftDeleteAddressAsync(Address address)
        {
            address.IsDeleted = true;
            _context.Addresses.Update(address);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAddress(Address address)
        {
            _context.Addresses.Update(address);
            await Task.CompletedTask;
        }

        public async Task RemoveDefaultAddressAsync(Guid userId)
        {
            var add = await _context.Addresses.Where(a => a.UserId == userId && a.IsDefault && !a.IsDeleted)
                .ToListAsync();
            foreach (var address in add) {
                address.IsDefault = false;
            }

            await _context.SaveChangesAsync();
        }
    }
}
