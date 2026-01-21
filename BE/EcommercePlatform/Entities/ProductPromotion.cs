namespace EcommercePlatform.Entities
{
    public class ProductPromotion
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public Guid PromotionId { get; set; }
        public Promotion Promotion { get; set; } = null!;
    }
}
