using System;
using System.Collections.Generic;

namespace MiniECommerce.Web.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItemListViewModel> OrderItems { get; set; } = new List<OrderItemListViewModel>();
    }
}