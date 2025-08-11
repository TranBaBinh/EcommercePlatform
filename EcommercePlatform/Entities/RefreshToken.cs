using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required , StringLength(500)]
        public string Token { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; } = false;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public User user { get; set; }
    }
}
