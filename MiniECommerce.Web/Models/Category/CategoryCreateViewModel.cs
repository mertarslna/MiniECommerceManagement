using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models.Category
{
    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }

}
