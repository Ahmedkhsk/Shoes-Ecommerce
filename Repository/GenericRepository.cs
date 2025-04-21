
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
