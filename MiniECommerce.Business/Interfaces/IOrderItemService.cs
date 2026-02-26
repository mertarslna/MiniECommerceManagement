using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Interfaces
{
    public interface IOrderItemService
    {
        // Adding, listing, updating and deleting functions for order items
        List<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Add(OrderItem category);
        void Update(OrderItem category);
        void Delete(int id);
    }
}