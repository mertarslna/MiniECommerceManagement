using MiniECommerce.Entity.Enums;

namespace MiniECommerce.Entity.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatuses Status { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}