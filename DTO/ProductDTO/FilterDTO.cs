namespace Shoes_Ecommerce.DTO.ProductDTO
{
    public class FilterDTO
    {
        public int categoryId { get; set; }
        public string targetGender { get; set; } = default!;
        public int sizeValue { get; set; }
        public double minPrice { get; set; }
        public double maxPrice { get; set; }
    }
}
