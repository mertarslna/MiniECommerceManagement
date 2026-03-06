using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Business.DTOs.Auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public required string Password { get; set; }
    }
}