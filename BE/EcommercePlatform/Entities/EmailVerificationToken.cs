using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class EmailVerificationToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Token { get; set; }  

        [Required]
        public DateTime ExpiresAt { get; set; }

        public bool IsUser { get; set; } = false;

        public User User { get; set; }

    }
}
