using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.DTOs.User
{
    public class UserLoginDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypes Type { get; set; }
    }
}
