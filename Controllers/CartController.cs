using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes_Ecommerce.DTO.CartDTO;

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
        public async Task<IActionResult> addCart(CartDTO cartDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await cartService.AddCartAsync(cartDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductAddedToCart", lan)));
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> removeCart(RemoveCartDTO cartDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await cartService.RemoveCartAsync(cartDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductRemovedFromCart", lan)));
        }

        [HttpGet("GetAll/{userId}")]
        public IActionResult getCarts(string userId, string lan = "en")
        {
            var products = cartService.GetCarts(userId);

            if (products == null || !products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoCartItemsFound", lan)));

            var filteredFavorites = EntityHelper.FilterEntitiesByLanguage(products, lan);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CartItemsRetrieved", lan), filteredFavorites));
        }
    }
}
