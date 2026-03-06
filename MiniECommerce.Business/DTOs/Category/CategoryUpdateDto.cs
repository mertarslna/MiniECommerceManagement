using MiniECommerce.Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Business.DTOs.Category
{
    public class CategoryUpdateDto
    {
        [Required(ErrorMessage = "Güncellenecek kategorinin kimlik bilgisi (Id) bulunamadı.")]
        public int Id { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2 ile 50 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }
    }
}