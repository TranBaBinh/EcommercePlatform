using System.ComponentModel.DataAnnotations;

namespace EcommercePlatform.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100,ErrorMessage = "Full name can't be longer than 100")]
        public string FullName { get; set; }

        [Required , EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
