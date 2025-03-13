namespace Shoes_Ecommerce.DTO.AuthenticationDTO
{
    public class ForgotPasswordDTO
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
