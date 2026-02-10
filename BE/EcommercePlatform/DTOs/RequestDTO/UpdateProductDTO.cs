namespace EcommercePlatform.DTOs.RequestDTO
{
    public class UpdateProductDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsActive { get; set; }
        public List<IFormFile>? NewImages { get; set; }
        public List<string>? ExistingImageUrls { get; set; } // URLs của ảnh giữ lại
    }
}
