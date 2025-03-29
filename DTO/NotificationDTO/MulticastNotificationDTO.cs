namespace Shoes_Ecommerce.DTO.NotificationDTO
{
    public class MulticastNotificationDTO
    {
        public List<string> Tokens { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
