using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.DTOs.Order
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatuses Status { get; set; }
    }
}
