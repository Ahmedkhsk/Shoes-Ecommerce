
namespace Shoes_Ecommerce.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository 
    {
        private readonly Context context;

        public CategoryRepository(Context context) : base(context)
        {
            this.context = context;
        }
        public Category GetCategoryIncludeAllProducts(int id)
        {
            return context.Categories
                     .Include(c => c.Products)
                         .ThenInclude(p => p.Variants)
                             .ThenInclude(v => v.Color)
                     .Include(c => c.Products)
                         .ThenInclude(p => p.Variants)
                             .ThenInclude(v => v.Size)
                     .Include(c => c.Products)
                         .ThenInclude(p => p.Images)
                     .AsNoTracking()
                     .FirstOrDefault(c => c.Id == id);

        }


    }
}
