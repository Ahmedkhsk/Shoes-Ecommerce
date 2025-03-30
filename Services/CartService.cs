using Shoes_Ecommerce.DTO.CartDTO;

namespace Shoes_Ecommerce.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ApplicationUser> userRepo;
        private readonly IGenericRepository<Cart> cartRepo;
        private readonly IGenericRepository<ProductVariant> variantRepo;

        public CartService(IGenericRepository<Product> productRepo,
            IGenericRepository<ApplicationUser> userRepo,
            IGenericRepository<Cart> cartRepo,
            IGenericRepository<ProductVariant> variantRepo)
        {
            this.productRepo = productRepo;
            this.userRepo = userRepo;
            this.cartRepo = cartRepo;
            this.variantRepo = variantRepo;
        }

        public async Task AddCartAsync(CartDTO cartDTO)
        {
            var user = await userRepo.GetByIdAsync(cartDTO.userId);
            var product = await productRepo.GetByIdAsync(cartDTO.productId);
            var variant = await variantRepo.GetByIdAsync(cartDTO.variantId);

            var cart = cartRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == cartDTO.userId && f.productId == cartDTO.productId);

            if (cart == null)
            {
                if (user != null && product != null && variant != null)
                {
                    await cartRepo.AddAsync(new Cart
                    {
                        productId = cartDTO.productId,
                        userId = cartDTO.userId,
                        variantId = cartDTO.variantId,
                        quantity = cartDTO.quantity
                    });

                    await cartRepo.Save();
                }
            }
        }

        public async Task RemoveCartAsync(RemoveCartDTO cartDTO)
        {
            var user = await userRepo.GetByIdAsync(cartDTO.userId);
            var product = await productRepo.GetByIdAsync(cartDTO.productId);

            if (user != null && product != null)
            {
                var cart = cartRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == cartDTO.userId && f.productId == cartDTO.productId);

                if (cart != null)
                    await cartRepo.DeleteAsync(cart.id);

                await cartRepo.Save();
            }
        }

        public List<Product> GetCarts(string id)
        {
            List<Product> products = cartRepo.GetProductsByUserIDInCart(id);
            return products;
        }

    
    }
}
