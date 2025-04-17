namespace Shoes_Ecommerce.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> categoryRepo;
        private readonly string imagePath;

        public CategoryService(IGenericRepository<Category> categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            this.categoryRepo = categoryRepo;
            imagePath = Path.Combine(webHostEnvironment.WebRootPath, FileSetting.ImagesPathCategory.TrimStart('/'));
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            string cover = await Images.SaveImage(categoryDto.ImageUrl, imagePath);

            Category newCategory = new Category();
            newCategory.NameEn = categoryDto.NameEn;
            newCategory.NameAr = categoryDto.NameAr;
            newCategory.ImageUrl = cover;

            await categoryRepo.AddAsync(newCategory);

            await categoryRepo.Save();
        }
        public async Task UpdateCategoryAsync(int id, CategoryDTO categoryFromDto)
        {
            Category categoryFormDb = await categoryRepo.GetByIdAsync(id);
            categoryFormDb.NameEn = categoryFromDto.NameEn;
            categoryFormDb.NameAr = categoryFromDto.NameAr;

            if (categoryFromDto.ImageUrl != null)
            {
                var oldImagePath = categoryFormDb.ImageUrl;
                string cover = await Images.SaveImage(categoryFromDto.ImageUrl, imagePath);
                categoryFormDb.ImageUrl = cover;
                Images.DeleteImage(oldImagePath, imagePath);
            }

            categoryRepo.Update(categoryFormDb);
            await categoryRepo.Save();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            Category categoryFormDb = await categoryRepo.GetByIdAsync(id);

            var imageUrl = categoryFormDb.ImageUrl;
            if (imageUrl != null)
            {
                Images.DeleteImage(imageUrl, imagePath);
            }
            await categoryRepo.DeleteAsync(id);
            await categoryRepo.Save();
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return categoryRepo.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await categoryRepo.GetByIdAsync(id);
        }


    }
}