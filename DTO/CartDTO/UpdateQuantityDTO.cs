namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class UpdateQuantityDTO
    {
        public string userId { get; set; } = string.Empty;
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
