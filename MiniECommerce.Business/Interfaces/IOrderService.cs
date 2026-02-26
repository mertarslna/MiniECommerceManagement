using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Interfaces
{
    public interface IOrderService
    {
        // Adding, listing, updating, status updating and deleting functions for orders
        List<Order> GetAll();
        Order GetById(int id);
        Order GetByIdWithDetails(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
        bool UpdateStatus(int id, string status);
    }
}