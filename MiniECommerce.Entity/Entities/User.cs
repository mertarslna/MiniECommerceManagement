using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Entity.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}