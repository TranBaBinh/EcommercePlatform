using EcommercePlatform.Entities;

namespace EcommercePlatform.DTOs.RequestDTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal StockQuanlity { get; set; }
        public Guid CategoryID { get; set; }

        public List<string> ImagesUrl { get; set; } = new List<string>(); 

    }
}
