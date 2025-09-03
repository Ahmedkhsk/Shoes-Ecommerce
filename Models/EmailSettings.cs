namespace Shoes_Ecommerce.Models
{
    public class EmailSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public string EmailFrom { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
