using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models
{
    public class ProductUpdateViewModel
    {
        [Required(ErrorMessage = "Güncellenecek kategorinin kimlik bilgisi (Id) bulunamadı.")]
        public int Id { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
