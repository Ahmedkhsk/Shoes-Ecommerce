namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
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
