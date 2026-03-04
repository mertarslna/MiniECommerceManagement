using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.Interfaces
{
    public interface IOrderService
    {
        // Adding, listing, updating, status updating and deleting functions for orders
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<IEnumerable<Order>> GetAllWithDetailsAsync();
        Task<Order> GetByIdWithDetailsAsync(int id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(int id);
        Task UpdateStatusAsync(int id, OrderStatuses status);
    }
}