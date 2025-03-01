namespace Shoes_Ecommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string verificationCode { get; set; } = generateVervicationCode();
        public bool IsApprove { get; set; }

        static string generateVervicationCode ()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999).ToString();
        }

    }
}
