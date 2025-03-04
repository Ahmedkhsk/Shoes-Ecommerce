namespace Shoes_Ecommerce.DTO
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        public string password { get; set; }
    }
}
