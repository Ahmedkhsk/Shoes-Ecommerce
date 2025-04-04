namespace Shoes_Ecommerce.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public void Update(T entity);
        public Task DeleteAsync(dynamic id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Category GetCategoryIncludeAllProducts(int id);
        public List<Product> getAllProductWithFilter(FilterDTO filterDTO);
        public List<Product> GetProductsByUserID(string id);
        public List<Product> GetProductsByUserIDInCart(string id);
        public Task<T> GetByIdAsync(dynamic id);
        public Task<Product> GetProductByIdAsync(int id);
        public Task Save();
    }
}
