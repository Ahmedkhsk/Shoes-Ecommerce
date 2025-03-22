namespace Shoes_Ecommerce.Services
{
    public interface IProductService
    {
        public Task AddProductAsync(ProductDTO product);
        public IEnumerable<Product> GetAllProducts(int CategoryId);
        Task UploadImagesAsync(int productId, List<IFormFile> images);
    }
}
