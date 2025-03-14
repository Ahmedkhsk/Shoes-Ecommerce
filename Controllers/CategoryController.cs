using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> AddCategory([FromBody]CategoryDTO categoryDTO,string lan = "en")
        {
             if(!ModelState.IsValid)
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("InvalidRequest", lan)));

            await categoryService.AddCategoryAsync(categoryDTO);

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoryAddedSuccess", lan)));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll([FromHeader] string lan = "en")
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            if (categories == null || !categories.Any())
                return BadRequest(new ApiResponse(false, LocalizationHelper.GetLocalizedMessage("NoCategoriesFound", lan)));

            return Ok(new ApiResponse(true, LocalizationHelper.GetLocalizedMessage("CategoriesRetrieved", lan), categories));
        }
    }
}
