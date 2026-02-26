namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // CRUD operations
        // Create, Read, Update, Delete
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}