using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models.Order
{
    public class OrderStatusUpdateViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } 

        [Required(ErrorMessage = "Sipariş durumu zorunludur.")]
        public string Status { get; set; }
    }
}