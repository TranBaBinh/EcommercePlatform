using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommercePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAddresses() {
         
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized(new { message = "Invalid token" });

            var userId = Guid.Parse(userIdClaim);
            var addresses = await _addressService.GetAddressesAsync(userId);

            return Ok(addresses);

        }
        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] AddressDTO addressDTO)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized(new { message = "Invalid token" });

            var userId = Guid.Parse(userIdClaim);
            var newAddress = await _addressService.AddAddressAsync(userId, addressDTO);

            return Ok(newAddress);
        }
        [HttpPut]
        public async Task<IActionResult> EditAddress([FromBody] AddressDTO addressDTO)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized(new { message = "Invalid token" });
            var userId = Guid.Parse(userIdClaim);
            var rs = await _addressService.UpdateAddressAsync(userId, addressDTO);
            return Ok(rs);
        }
        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
                return Unauthorized(new { message = "Invalid token" });
            var userId = Guid.Parse(userIdClaim);
            var rs = await _addressService.DeleteAddressAsync(userId, addressId);
            return Ok(rs);
        }
    }
}
