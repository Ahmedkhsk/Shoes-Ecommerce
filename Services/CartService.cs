using Shoes_Ecommerce.DTO.CartDTO;
using System.Threading.Tasks;

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

        public async Task<GetCartDTO> GetCarts(string id)
        {
            GetCartDTO getCartDTO = new GetCartDTO();
            double totalPrice = 0;
            List<Product> products = cartRepo.GetProductsByUserIDInCart(id);
            List<getProductsOfCart> productsOfCarts = new List<getProductsOfCart>();
            foreach (var product in products)
            {
                var cart = cartRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == id && f.productId == product.Id);
                var variant = await variantRepo.GetByIdAsync(cart.variantId);
                productsOfCarts.Add(new getProductsOfCart
                {
                    productId = product.Id,
                    productNameEn = product.NameEn,
                    productNameAr = product.NameAr,
                    price = product.Price,
                    quantity = cart.quantity,
                    imageName = product.Images.ToList()[0].ImageUrl,
                    productSizeName = variant.Size.sizeName
                });
                totalPrice += product.Price * cart.quantity;
            }
            getCartDTO.products = productsOfCarts;
            getCartDTO.totalPrice = totalPrice;
            return getCartDTO;
        }

        public async Task<Cart> UpdateQuantity(int productId, string userId, int quantity)
        {
            var cart = cartRepo.GetAllAsync().Result.FirstOrDefault(f => f.userId == userId && f.productId == productId);
            cart.quantity = quantity;
            cartRepo.Update(cart);
            await cartRepo.Save();
            return cart;
        }
    }
}
