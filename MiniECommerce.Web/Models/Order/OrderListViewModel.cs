namespace MiniECommerce.Web.Models
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public required string OrderNumber { get; set; }
        public int UserId { get; set; }
        public required string UserName { get; set; }
    }
}
