namespace Shoes_Ecommerce.DTO
{
    public class CategoryDTO
    {
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public IFormFile? ImageUrl { get; set; } = default!;

    }
}
