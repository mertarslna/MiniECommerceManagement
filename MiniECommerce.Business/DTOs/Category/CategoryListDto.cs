using MiniECommerce.Entity.Enums;
using System;

namespace MiniECommerce.Business.DTOs.Category
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public UserType CreatedBy { get; set; }
        public UserType UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}