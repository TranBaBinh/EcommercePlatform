namespace EcommercePlatform.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaidAt { get; set; }

        public Order Order { get; set; }
    }
}
