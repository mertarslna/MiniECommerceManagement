using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Concrete
{
    public class OrderItemService : IOrderItemService
    {
        // Adding, listing, updating, deleting and soft deleting functions for order items
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }
        public List<OrderItem> GetAll() => _repository.GetAll();
        public OrderItem GetById(int id) => _repository.GetById(id);
        public void Add(OrderItem orderItem) { _repository.Add(orderItem); }
        public void Update(OrderItem orderItem) { _repository.Update(orderItem); }
        public void Delete(int id)
        {
            var orderItem = _repository.GetById(id);
            if (orderItem != null)
                _repository.Delete(orderItem);
        }
    }
}