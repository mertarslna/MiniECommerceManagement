using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Order GetOrderWithDetails(int id);
    }
}