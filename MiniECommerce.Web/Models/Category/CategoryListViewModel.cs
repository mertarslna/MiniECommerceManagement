using System;
using System.ComponentModel;

namespace MiniECommerce.Web.Models
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        public required string Name { get; set; }

        [DisplayName("Açıklama")]
        public string? Description { get; set; }

        [DisplayName("Durum")]
        public bool IsActive { get; set; }

        [DisplayName("Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
    }
}