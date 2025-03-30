namespace Shoes_Ecommerce.DTO.CartDTO
{
    public class RemoveCartDTO
    {
        public int productId { get; set; }
        public string userId { get; set; } = default!;
    }
}
