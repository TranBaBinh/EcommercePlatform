using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required , StringLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0 , double.MaxValue)]
        public decimal OriginalPrice { get; set; }
        [Range(0 , double.MaxValue)]
        public decimal CurrentPrice { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();

    }
}
