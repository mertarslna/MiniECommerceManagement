using MiniECommerce.Entity.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiniECommerce.Business.DTOs.OrderItem;

namespace MiniECommerce.Business.DTOs.Order
{
    public class OrderUpdateDto
    {
        [Required(ErrorMessage = "Güncellenecek siparişin kimlik bilgisi (Id) bulunamadı.")]
        public int Id { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemUpdateDto> OrderItems { get; set; } = new List<OrderItemUpdateDto>();
    }
}