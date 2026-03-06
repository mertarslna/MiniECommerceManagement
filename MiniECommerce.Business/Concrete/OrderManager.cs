using AutoMapper;
using MiniECommerce.Business.DTOs.Order;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderManager(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderListDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderListDto>>(orders);
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllWithDetailsAsync()
        {
            var orders = await _repository.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<OrderDetailDto>>(orders);
        }

        public async Task<OrderListDto> GetByIdAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new Exception("Order not found.");

            return _mapper.Map<OrderListDto>(order);
        }

        public async Task<OrderDetailDto> GetByIdWithDetailsAsync(int id)
        {
            var order = await _repository.GetByIdWithDetailsAsync(id);
            if (order == null)
                throw new Exception("Order not found.");

            return _mapper.Map<OrderDetailDto>(order);
        }

        public async Task UpdateAsync(OrderUpdateDto dto)
        {
            var existingOrder = await _repository.GetByIdAsync(dto.Id);
            if (existingOrder == null)
                throw new Exception("Order not found.");

            _mapper.Map(dto, existingOrder);

            _repository.Update(existingOrder);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(int id, OrderStatus status)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new Exception("Order not found.");

            order.Status = status;
            _repository.Update(order);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null)
                throw new Exception("Order not found.");

            _repository.Delete(order);
            await _repository.SaveChangesAsync();
        }
    }
}