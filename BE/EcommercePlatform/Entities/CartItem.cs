using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // Giá tại thời điểm thêm vào giỏ
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
