namespace EcommercePlatform.DTOs.RequestDTO
{
    public class AddressDTO
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public bool IsDefault { get; set; }
    }
}
