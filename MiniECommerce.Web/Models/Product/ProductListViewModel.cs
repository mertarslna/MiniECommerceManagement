using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.ViewModels.Product
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}