using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Entity.Entities
{
    public class User : BaseEntity
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public UserTypes UserType { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}