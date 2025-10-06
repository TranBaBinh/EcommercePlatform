using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        // Giá tại thời điểm mua (lưu cố định, không thay đổi)
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
