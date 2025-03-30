using Shoes_Ecommerce.DTO.CartDTO;

namespace Shoes_Ecommerce.Services
{
    public interface ICartService
    {
        public Task AddCartAsync(CartDTO cartDTO);
        public Task RemoveCartAsync(RemoveCartDTO cartDTO);
        public List<Product> GetCarts(string id);
    }
}
