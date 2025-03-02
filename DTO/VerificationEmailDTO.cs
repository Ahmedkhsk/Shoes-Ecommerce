namespace Shoes_Ecommerce.DTO
{
    public class VerificationEmailDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string VerificationCode { get; set; }
    }
}
