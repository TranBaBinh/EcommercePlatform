using EcommercePlatform.Entities;

namespace EcommercePlatform.DTOs.RequestDTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }

        public List<IFormFile>? ImagesUrl { get; set; }

    }
}
