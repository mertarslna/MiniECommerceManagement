using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsWithCategories();
    }
}