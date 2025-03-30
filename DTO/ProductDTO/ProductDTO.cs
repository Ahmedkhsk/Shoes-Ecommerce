namespace Shoes_Ecommerce.DTO.ProductDTO
{
    public class ProductDTO
    {
        public string NameEn { get; set; } = string.Empty;
        public string NameAr { get; set; } = string.Empty;
        public double Price { get; set; }
        public double discount { get; set; }
        public string descriptionEn { get; set; } = string.Empty;
        public string descriptionAr { get; set; } = string.Empty;
        public string targetGender { get; set; } = default!;
        public List<ProductVariantDTO> ProductVariants { get; set; } = new List<ProductVariantDTO>();
        public int Category { get; set; }
    }
}

