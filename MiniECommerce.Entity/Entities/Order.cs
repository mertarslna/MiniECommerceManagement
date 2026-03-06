using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Entity.Entities
{
    public class Order : BaseEntity
    {
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual User User { get; set; }
    }
}