using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.ViewModels.Product
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stok adedi negatif olamaz.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}