using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
