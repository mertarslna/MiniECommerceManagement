using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Business.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2 ile 50 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Açıklama alanı en fazla 250 karakter olabilir.")]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}