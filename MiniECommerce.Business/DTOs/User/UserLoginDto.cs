using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Business.DTOs.User
{
    public class UserLoginDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserTypes Type { get; set; }
    }
}
