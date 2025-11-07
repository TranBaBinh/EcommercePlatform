using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required , StringLength(500)]
        public string Token { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; } = false;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
