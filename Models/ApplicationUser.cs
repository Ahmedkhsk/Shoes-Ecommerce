namespace Shoes_Ecommerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Addresse { get; set; }
        public string vervicationCode { get; set; } = generateVervicationCode();
        public bool MyProperty { get; set; }

        static string generateVervicationCode ()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999).ToString();
        }

    }
}
