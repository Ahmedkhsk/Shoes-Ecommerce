namespace Shoes_Ecommerce.DTO.ProductDTO
{
    public class getProductsOfCart
    {
        public int productId { get; set; }
        public string productNameEn { get; set; } = string.Empty;
        public string productNameAr { get; set; } = string.Empty;
        public string productSizeName { get; set; } = string.Empty;
        public double price { get; set; }
        public string imageName { get; set; } = string.Empty;
        public int quantity { get; set; }
    }
}
