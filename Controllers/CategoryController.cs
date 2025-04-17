namespace Shoes_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromForm] CategoryDTO categoryDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await categoryService.AddCategoryAsync(categoryDTO);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoryAddedSuccess", lan)));   
        }
        
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromForm] CategoryDTO categoryDTO, string lan = "en")
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("CategoryNotFound", lan)));
            await categoryService.UpdateCategoryAsync(id, categoryDTO);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoryUpdatedSuccess", lan), category));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id, string lan = "en")
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("CategoryNotFound", lan)));
            await categoryService.DeleteCategoryAsync(id);
            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoryDeletedSuccess", lan)));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll(string lan = "en")
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoCategoriesFound", lan)));

            var filteredCategories = EntityHelper.FilterEntitiesByLanguage(categories, lan);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoriesRetrieved", lan), filteredCategories));
        }
    }
}
