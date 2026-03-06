using MiniECommerce.Business.DTOs;
using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.DTOs.Order
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
        public required string UserName { get; set; }
    }
}
