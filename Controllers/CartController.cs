using System.Threading.Tasks;

namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IProductService productService;

        public CartController(ICartService cartService,IProductService productService)
        {
            this.cartService = cartService;
            this.productService = productService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCart(CartDTO cartDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await cartService.AddCartAsync(cartDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductAddedToCart", lan)));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveCart(RemoveCartDTO cartDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await cartService.RemoveCartAsync(cartDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductRemovedFromCart", lan)));
        }

        [HttpPut("UpdateQuantity")]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityDTO updateQuantityDTO, string lan = "en")
        {
            if (updateQuantityDTO.quantity < 1)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidQuantity", lan)));

            Cart cart = await cartService.UpdateQuantity(updateQuantityDTO.productId, updateQuantityDTO.userId, updateQuantityDTO.quantity);
            
            if (cart != null)
            {
                var product = await productService.GetProductById(cart.productId);
                
                if (product == null)
                    return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("ProductNotFound", lan)));

                getProductsOfCart getProductsOfCart = new getProductsOfCart
                {
                    productId = product.Id,
                    productNameEn = product.NameEn,
                    productNameAr = product.NameAr,
                    price = product.Price,
                    quantity = cart.quantity,
                    imageName = product.Images.ToList()[0].ImageUrl,
                    productSizeName = cart.variant.Size.sizeName
                };

                var filteredProducts = EntityHelper.FilterEntitiesByLanguage(new List<getProductsOfCart> { getProductsOfCart }, lan);

                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductQuantityUpdated", lan), filteredProducts));
            }

            return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoCartItemsFound", lan)));
        }
        [HttpGet("GetAll/{userId}")]
        public async Task<IActionResult> GetCarts(string userId, string lan = "en")
        {
            GetCartDTO cart =  await cartService.GetCarts(userId);

            if (cart.products == null || !cart.products.Any())
            {
                cart.products = new List<getProductsOfCart>();
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoCartItemsFound", lan)));
            }

            var filteredProducts = EntityHelper.FilterEntitiesByLanguage(cart.products, lan);

            var filteredCart = new EntityCartDTO();

            filteredCart.products = filteredProducts;
            filteredCart.totalPrice = cart.totalPrice;
  
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CartItemsRetrieved", lan), filteredCart));
        }
    }
}
