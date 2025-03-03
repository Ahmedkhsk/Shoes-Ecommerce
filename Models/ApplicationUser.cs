namespace Shoes_Ecommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string? verificationCode { get; set; } = default!;
        public bool IsApprove { get; set; }

    }
}
