using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2-50 karakter arasında olmalıdır.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public required string Password { get; set; }
    }
}