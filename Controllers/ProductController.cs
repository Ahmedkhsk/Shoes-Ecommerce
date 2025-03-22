using Shoes_Ecommerce.DTO.ProductDTO;
using Shoes_Ecommerce.Services;
using System.Threading.Tasks;

namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO, string lan = "en")
        {
            if(!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await productService.AddProductAsync(productDTO);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductAddedSuccess", lan)));
        }

        [HttpPost("UploadImages/{productId}")]
        public async Task<IActionResult> UploadImages(int productId, [FromForm] List<IFormFile> images, string lan = "en")
        {
            try
            {
                await productService.UploadImagesAsync(productId, images);
                return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ImagesUploadedSuccessfully", lan)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(false, ex.Message));
            }
        }

        [HttpGet("GetAll/{categoryId}")]
        public ActionResult GetAll(int categoryId, string lan = "en")
        {
            var Products =  productService.GetAllProducts(categoryId);
            if (Products == null || !Products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoProductsFound", lan), Enumerable.Empty<Product>()));

            var filteredProducts = EntityHelper.FilterEntitiesByLanguage(Products, lan);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductsRetrieved", lan), filteredProducts));
        }
    }
}
