namespace Shoes_Ecommerce.DTO
{
    public class RegisterDTO
    {
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
