namespace Shoes_Ecommerce.Services
{
    public interface IProductService
    {
        public Task AddProductAsync(ProductDTO product);
        public Task<Product> UpdateProductAsync(int productId, ProductDTO product);
        public Task DeleteProductAsync(int productId);
        public IEnumerable<Product> GetAllProducts(int CategoryId);
        public IEnumerable<Product> GetAllProductsWithFilter(FilterDTO filterDTO);
        public Task<Product> GetProductById(int id);
        public List<Product> GetProductsInSearch(string name);
        Task UploadImagesAsync(int productId, List<IFormFile> images);
    }
}
