

using Shoes_Ecommerce.Data;

namespace Shoes_Ecommerce.Repository
{
    public class ProductRepository :GenericRepository<Product>, IProductRepository
    {
        private readonly Context context;

        public ProductRepository(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                .Include(p => p.Variants)
                    .ThenInclude(p => p.Color)
                .Include(p => p.Variants)
                    .ThenInclude(p => p.Size)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        public List<Product> getAllProductWithFilter(FilterDTO filterDTO)
        {
            if (filterDTO.targetGender == "All")
                return context.Products
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.Color)
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.Size)
                    .Include(p => p.Images)
                    .Where(p => p.CategoryID == filterDTO.categoryId)
                    .Where(p => p.Variants.Any(v => v.Size.SizeValue == filterDTO.sizeValue))
                    .Where(p => p.Price > filterDTO.minPrice && p.Price < filterDTO.maxPrice)
                    .AsNoTracking()
                    .ToList();

            else
                return context.Products
                   .Include(p => p.Variants)
                       .ThenInclude(v => v.Color)
                   .Include(p => p.Variants)
                       .ThenInclude(v => v.Size)
                   .Include(p => p.Images)
                   .Where(p => p.CategoryID == filterDTO.categoryId)
                   .Where(p => p.Variants.Any(v => v.Size.SizeValue == filterDTO.sizeValue))
                   .Where(p => p.Price > filterDTO.minPrice && p.Price < filterDTO.maxPrice)
                   .Where(p => p.targetGender.Equals(filterDTO.targetGender))
                   .AsNoTracking()
                   .ToList();
        }
        public List<Product> GetProductsByUserIDInFavorite(string id)
        {
            List<Product> products = context.Favorites
                .Include(f => f.Product)
                    .ThenInclude(p => p.Variants)
                        .ThenInclude(v => v.Color)
                .Include(f => f.Product)
                    .ThenInclude(p => p.Variants)
                        .ThenInclude(v => v.Size)
                .Include(f => f.Product)
                    .ThenInclude(p => p.Images)
                .Where(f => f.userId == id)
                .Select(f => f.Product)
                .ToList();

            return products;
        }
        public List<Product> GetProductsByUserIDInCart(string id)
        {
            List<Product> products = context.Carts
                .Include(f => f.product)
                    .ThenInclude(p => p.Variants)
                        .ThenInclude(v => v.Color)
                .Include(f => f.product)
                    .ThenInclude(p => p.Variants)
                        .ThenInclude(v => v.Size)
                .Include(f => f.product)
                    .ThenInclude(p => p.Images)
                .Where(f => f.userId == id)
                .Select(f => f.product)
                .ToList();

            return products;
        }
        public List<Product> GetProductsInSearch(string name)
        {
            if (string.IsNullOrEmpty(name))
                return new List<Product>();

            return context.Products
                    .Include(p => p.Variants)
                        .ThenInclude(p => p.Color)
                    .Include(p => p.Variants)
                        .ThenInclude(p => p.Size)
                    .Include(p => p.Images)
                    .Where(c => (c.NameEn ?? "").ToLower().Contains(name.ToLower()) ||
                                (c.NameAr ?? "").ToLower().Contains(name.ToLower()))
                    .ToList();
        }

    }
}
