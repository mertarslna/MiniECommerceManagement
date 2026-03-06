using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models.Category
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2 ile 50 karakter arasında olmalıdır.")]
        [Display(Name = "Kategori Adı")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
    }
}