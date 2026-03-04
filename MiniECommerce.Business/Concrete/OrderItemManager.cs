using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemManager(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<OrderItem> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than zero.");

            var orderItem = await _repository.GetByIdAsync(id);

            if (orderItem == null)
                throw new KeyNotFoundException($"OrderItem with Id {id} not found.");

            return orderItem;
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await _repository.AddAsync(orderItem);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));

            _repository.Update(orderItem);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await GetByIdAsync(id);

            _repository.Delete(orderItem);
            await _repository.SaveChangesAsync();
        }
    }
}