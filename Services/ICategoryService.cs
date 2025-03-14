namespace Shoes_Ecommerce.Services
{
    public interface ICategoryService
    {
        public Task AddCategoryAsync(CategoryDTO category);
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
    }
}
