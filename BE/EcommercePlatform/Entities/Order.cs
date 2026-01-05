namespace EcommercePlatform.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid ShippingAddressId { get; set; }

        public User User { get; set; }
        public Address ShippingAddress { get; set; }

        public Voucher Voucher { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
