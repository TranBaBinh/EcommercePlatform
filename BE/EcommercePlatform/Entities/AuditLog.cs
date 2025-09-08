namespace EcommercePlatform.Entities
{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
