using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;


namespace MiniECommerce.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderManager(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Order> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid order ID.");

            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllWithDetailsAsync() => await _repository.GetAllWithDetailsAsync();

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid order ID.");

            var order = await _repository.GetByIdWithDetailsAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            return order;
        }

        public async Task AddAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");

            await _repository.AddAsync(order);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");

            var existingOrder = await _repository.GetByIdAsync(order.Id);
            if (existingOrder == null)
                throw new KeyNotFoundException("Order not found.");

            _repository.Update(order);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid order ID.");

            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            _repository.Delete(order);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, OrderStatuses status)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid order ID.");

            if (!Enum.IsDefined(typeof(OrderStatuses), status))
                throw new ArgumentException("Invalid order status value.");

            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new KeyNotFoundException("Order not found.");

            order.Status = status;

            _repository.Update(order);
            await _repository.SaveChangesAsync();
        }
    }
}