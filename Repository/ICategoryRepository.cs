namespace Shoes_Ecommerce.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Category GetCategoryIncludeAllProducts(int id);
    }
}

