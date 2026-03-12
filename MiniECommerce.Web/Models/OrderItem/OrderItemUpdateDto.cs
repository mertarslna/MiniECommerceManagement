namespace MiniECommerce.Web.Models
{
    public class OrderItemUpdateDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}