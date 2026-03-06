using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Business.DTOs.Category
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Kategori adı 2-50 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}