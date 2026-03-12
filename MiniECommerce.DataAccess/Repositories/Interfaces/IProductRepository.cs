using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithCategoriesAsync();
        Task<Product> GetByIdWithCategoriesAsync(int id);
    }
}