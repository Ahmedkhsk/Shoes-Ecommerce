namespace Shoes_Ecommerce.DTO.AuthenticationDTO
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        public string password { get; set; }
    }
}
