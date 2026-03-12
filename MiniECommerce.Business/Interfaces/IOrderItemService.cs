using MiniECommerce.Business.DTOs.OrderItem;

namespace MiniECommerce.Business.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemListDto>> GetAllAsync();
        Task<OrderItemListDto> GetByIdAsync(int id);
        Task UpdateAsync(OrderItemUpdateDto dto);
        Task DeleteAsync(int id);
        Task<bool> ToggleActivationAsync(int id);

    }
}