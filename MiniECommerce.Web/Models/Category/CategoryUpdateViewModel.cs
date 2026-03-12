using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models
{
    public class CategoryUpdateViewModel
    {
        [Required(ErrorMessage = "Güncellenecek kategorinin kimlik bilgisi (Id) bulunamadı.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2 ile 50 karakter arasında olmalıdır.")]
        [Display(Name = "Kategori Adı")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }
    }
}