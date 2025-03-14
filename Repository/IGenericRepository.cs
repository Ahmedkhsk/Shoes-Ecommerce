namespace Shoes_Ecommerce.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public void Update(T entity);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public void Save();

    }
}
