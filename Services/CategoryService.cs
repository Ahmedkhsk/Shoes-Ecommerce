
namespace Shoes_Ecommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> categoryRepo;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string imagePath;

        public CategoryService(IGenericRepository<Category> categoryRepo,IWebHostEnvironment webHostEnvironment)
        {
            this.categoryRepo = categoryRepo;
            this.webHostEnvironment = webHostEnvironment;
            imagePath = $"{webHostEnvironment.WebRootPath}{FileSetting.ImagesPathCategory}";
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            string cover = await Images.SaveImage(categoryDto.ImageUrl,imagePath);

            Category newCategory = new Category();
            newCategory.NameEn = categoryDto.NameEn;
            newCategory.NameAr = categoryDto.NameEn;
            newCategory.ImageUrl = cover;
            
            await categoryRepo.AddAsync(newCategory);
            
            categoryRepo.Save();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return categoryRepo.GetAllAsync();
        }
    }
}
