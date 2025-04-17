namespace Shoes_Ecommerce.Services
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryDTO category);
        public Task UpdateCategoryAsync(int id, CategoryDTO category);
        public Task DeleteCategoryAsync(int id);
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
