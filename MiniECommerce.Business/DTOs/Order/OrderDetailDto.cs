using MiniECommerce.Business.DTOs.OrderItem;
using MiniECommerce.Entity.Enums;
using System;
using System.Collections.Generic;

namespace MiniECommerce.Business.DTOs.Order
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatuses Status { get; set; }
        public List<OrderItemListDto> OrderItems { get; set; } = new List<OrderItemListDto>();
    }
}