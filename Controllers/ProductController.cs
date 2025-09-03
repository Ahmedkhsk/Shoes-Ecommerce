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

        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO, string lan = "en")
        {
            if(!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await productService.AddProductAsync(productDTO);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductAddedSuccess", lan)));
        }
        [HttpPut("Update/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductDTO productDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));
            var product = await productService.GetProductById(productId);
            if (product == null)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("ProductNotFound", lan)));
            await productService.UpdateProductAsync(productId, productDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductUpdatedSuccess", lan)));
        }

        [HttpDelete("Delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId, string lan = "en")
        {
            var product = await productService.GetProductById(productId);
            if (product == null)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("ProductNotFound", lan)));
            await productService.DeleteProductAsync(productId);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductDeletedSuccess", lan)));
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
        
        [HttpGet("Filter")]
        public IActionResult Filter([FromQuery]FilterDTO filterDTO, string lan = "en")
        {
            var Products = productService.GetAllProductsWithFilter(filterDTO);
            if (Products == null || !Products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoProductsFound", lan), Enumerable.Empty<Product>()));

            var filteredProducts = EntityHelper.FilterEntitiesByLanguage(Products, lan);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductsRetrieved", lan), filteredProducts));
        }

        [HttpGet("Search")]
        public IActionResult Serach(string name ,string lan = "en")
        {
           var products = productService.GetProductsInSearch(name);

            if(products == null || !products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoProductsFound", lan), Enumerable.Empty<Product>()));
           
            var filteredProducts = EntityHelper.FilterEntitiesByLanguage(products, lan);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductsRetrieved", lan), filteredProducts));
        }

        [HttpGet("GetAll/{categoryId}")]
        public IActionResult GetAll(int categoryId, int pageNumber, string lan = "en")
        {
            var Products =  productService.GetAllProducts(categoryId);
            if (Products == null || !Products.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoProductsFound", lan), Enumerable.Empty<Product>()));

            var filteredProducts = EntityHelper.FilterEntitiesByLanguage(Products, lan);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("ProductsRetrieved", lan), filteredProducts));
        }

    }
}
