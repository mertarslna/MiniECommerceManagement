using AutoMapper;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.DTOs.OrderItem;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;

namespace MiniECommerce.Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemManager(IOrderItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var orderItem = await _repository.GetByIdAsync(id);
            if (orderItem == null)
                throw new Exception("OrderItem not found.");

            _repository.Update(orderItem);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItemListDto>> GetAllAsync()
        {
            var orderItems = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderItemListDto>>(orderItems);
        }

        public async Task<OrderItemListDto> GetByIdAsync(int id)
        {

            if (id <= 0)
                throw new Exception("OrderItem not found.");

            var orderItem = await _repository.GetByIdAsync(id);

            return _mapper.Map<OrderItemListDto>(orderItem);
        }

        public async Task UpdateAsync(OrderItemUpdateDto dto)
        {
            var orderItem = await _repository.GetByIdAsync(dto.Id);
            if (orderItem != null)
                throw new Exception("OrderItem not found.");

            _mapper.Map(dto, orderItem);

            orderItem.UpdatedDate = DateTime.Now;

            _repository.Update(orderItem);
            await _repository.SaveChangesAsync();
        }
    }
}