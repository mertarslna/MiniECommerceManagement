using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.DataAccess.Repositories.Concrete;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Concrete
{
    public class OrderService : IOrderService
    {
        // Adding, listing, updating, status updating and deleting functions for orders
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public List<Order> GetAll() { return _repository.GetAll(); }
        public Order GetById(int id) { return _repository.GetById(id); }
        public Order GetByIdWithDetails(int id)
        {
            return _repository.GetOrderWithDetails(id);
        }
        public void Add(Order order) { _repository.Add(order); }
        public void Update(Order order) { _repository.Update(order); }
        public void Delete(int id) { _repository.Delete(_repository.GetById(id)); }
        public bool UpdateStatus(int id, string status)
        {
            var order = _repository.GetById(id);
            if (order != null)
            {
                order.Status = status;
                _repository.Update(order);
                return true;
            }
            return false;
        }
    }
}