namespace Shoes_Ecommerce.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<Product> GetProductByIdAsync(int id);
        public List<Product> GetProductsInSearch(string name);
        public List<Product> GetProductsByUserIDInCart(string id);
        public List<Product> GetProductsByUserIDInFavorite(string id);
        public List<Product> getAllProductWithFilter(FilterDTO filterDTO);
        
    }
    
}
