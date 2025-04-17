namespace Shoes_Ecommerce.Models
{
    public class UserNotification
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string userId { get; set; } = string.Empty;
        public ApplicationUser Users { get; set; } = default!;

    }
}
