namespace EcommercePlatform.Entities
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public bool IsDefault { get; set; } = false;

        public User User { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
