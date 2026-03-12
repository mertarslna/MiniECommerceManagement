namespace MiniECommerce.Web.Models
{
    public class OrderItemListViewModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductName { get; set; }
    }
}
