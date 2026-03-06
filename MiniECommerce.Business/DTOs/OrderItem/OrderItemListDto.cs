using MiniECommerce.Business.DTOs.Order;
using MiniECommerce.Business.DTOs.Product;

namespace MiniECommerce.Business.DTOs.OrderItem
{
    public class OrderItemListDto
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
