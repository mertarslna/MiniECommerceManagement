using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Business.DTOs.Product
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Ürün adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ürün adı 2 ile 50 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
