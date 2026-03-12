using System.ComponentModel.DataAnnotations;

namespace MiniECommerce.Web.Models
{
    public class ProductListViewModel
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        public required string CategoryName { get; set; }
    }
}