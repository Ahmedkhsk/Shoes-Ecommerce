namespace Shoes_Ecommerce.DTO.AuthenticationDTO
{
    public class updateUserDTO
    {
        public string userId { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public IFormFile imageName { get; set; } = default!;

    }
}
