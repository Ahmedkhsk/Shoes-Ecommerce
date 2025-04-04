namespace Shoes_Ecommerce.Services
{
    public interface ICartService
    {
        public Task AddCartAsync(CartDTO cartDTO);
        public Task RemoveCartAsync(RemoveCartDTO cartDTO);
        public Task<Cart> UpdateQuantity(int productId , string userId, int quantity);
        public Task<GetCartDTO> GetCarts(string id);
    }
}
