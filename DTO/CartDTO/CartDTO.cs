namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class CartDTO
    {
        public int productId { get; set; }
        public string userId { get; set; } = default!;
        public int variantId { get; set; }
        public int quantity { get; set; }

    }
}
