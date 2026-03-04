using System;

namespace MiniECommerce.Business.DTOs.Category
{
    public class CategoryListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}