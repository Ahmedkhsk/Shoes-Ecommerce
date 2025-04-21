using System.Threading.Tasks;

namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> addfavorite(FavoriteAddDTO favoriteDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await favoriteService.AddFavoriteAsync(favoriteDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductAddedToFavorites", lan)));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> updatefavorite(FavoriteAddDTO favoriteDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));
            await favoriteService.UpdateFavoriteAsync(favoriteDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductUpdatedInFavorites", lan)));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> removefavorite(FavoriteAddDTO favoriteDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await favoriteService.RemoveFavoriteAsync(favoriteDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductRemovedFromFavorites", lan)));
        }


        
        [HttpGet("GetAll/{userId}")]
        public IActionResult getfavorites(string userId, string lan = "en")
        {
            var products = favoriteService.GetFavorites(userId);

            if (products == null || !products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoFavoritesFound", lan)));
            
            var filteredFavorites = EntityHelper.FilterEntitiesByLanguage(products, lan);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("FavoritesRetrieved", lan), filteredFavorites));
        }
    }
}
