
using System.Threading.Tasks;

namespace Shoes_Ecommerce.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context context;
        private readonly DbSet<T> dbSet;
        public GenericRepository(Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(dynamic id) => await dbSet.FindAsync(id);
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

        public List<Product> GetProductsByUserID(string id)
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

        public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);
        public  void Update(T entity) =>  dbSet.Update(entity);
        public async Task DeleteAsync(dynamic id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
                dbSet.Remove(entity);
        }
      
        public async Task Save() => await context.SaveChangesAsync();
        

    }
}
