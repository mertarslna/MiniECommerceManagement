using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models
{
    public class OrderUpdateViewModel
    {
        [Required(ErrorMessage = "Güncellenecek siparişin kimlik bilgisi (Id) bulunamadı.")]
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public List<OrderItemUpdateDto> OrderItems { get; set; } = new List<OrderItemUpdateDto>();
    }
}