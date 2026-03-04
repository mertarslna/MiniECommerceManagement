using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(int id);
        Task AddAsync(OrderItem orderitem);
        Task UpdateAsync(OrderItem orderitem);
        Task DeleteAsync(int id);
    }
}