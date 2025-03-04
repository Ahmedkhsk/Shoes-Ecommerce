namespace Shoes_Ecommerce.DTO
{
    public class changePassDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }

    }
}
