namespace EcommercePlatform.Entities
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
