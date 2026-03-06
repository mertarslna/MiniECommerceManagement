using MiniECommerce.Entity.Enums;
using MiniECommerce.Business.DTOs.Order;

namespace MiniECommerce.Business.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderListDto>> GetAllAsync();
        Task<OrderListDto> GetByIdAsync(int id);
        Task<IEnumerable<OrderDetailDto>> GetAllWithDetailsAsync();
        Task<OrderDetailDto> GetByIdWithDetailsAsync(int id);
        Task UpdateAsync(OrderUpdateDto dto);
        Task DeleteAsync(int id);
        Task UpdateStatusAsync(int id, OrderStatus status);
    }
}