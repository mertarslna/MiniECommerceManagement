namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // CRUD operations
        // Create, Read, Update and Delete operations for the entity T

        /* Senkron yapıdaki CRUD işlemleri için örnek metot imzaları:
        void Add(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        */

        // Asenkron yapıdaki CRUD işlemleri için örnek metot imzaları:
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}