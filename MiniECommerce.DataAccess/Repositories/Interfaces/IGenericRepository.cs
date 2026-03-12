namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        void ToggleActivation(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}