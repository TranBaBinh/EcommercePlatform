using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required , StringLength(500)]
        public string ImageUrl { get; set; }
        public bool IsThumbnail { get; set; } = false;

        public Product Product { get; set; }
    }
}
