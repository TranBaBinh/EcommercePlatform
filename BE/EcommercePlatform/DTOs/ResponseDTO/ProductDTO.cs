namespace EcommercePlatform.DTOs.ResponseDTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int StockQuantity { get; set; }

        public decimal Price { get; set; } 
        public decimal CurrentPrice { get; set; } 
        public decimal DiscountPercent { get; set; }
        public string? PromotionName { get; set; } 
        public string CategoryName { get; set; } = string.Empty;
        public string SellerName { get; set; } = string.Empty;
        public string? ThumbnailUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
