namespace MiniECommerce.Entity.Entities
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual required Order Order { get; set; }
        public virtual required Product Product { get; set; }
    }
}