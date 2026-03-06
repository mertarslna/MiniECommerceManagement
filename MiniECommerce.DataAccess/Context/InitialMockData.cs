using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Helpers;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;

public static class InitialMockData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        DateTime seedDate = new DateTime(2026, 03, 06);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Elektronik", CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Category { Id = 2, Name = "Giyim", CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Category { Id = 3, Name = "Ev & Yaşam", CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Category { Id = 4, Name = "Kitap & Hobi", CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Category { Id = 5, Name = "Spor & Outdoor", CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Mert Arslan", Email = "mert@admin.com", Password = PasswordHelper.HashPassword("123"), UserType = UserType.Administrator, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new User { Id = 2, Name = "Ahmet Yılmaz", Email = "ahmet@test.com", Password = PasswordHelper.HashPassword("123"), UserType = UserType.Customer, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new User { Id = 3, Name = "Ayşe Demir", Email = "ayse@test.com", Password = PasswordHelper.HashPassword("123"), UserType = UserType.Customer, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new User { Id = 4, Name = "Mehmet Can", Email = "mehmet@test.com", Password = PasswordHelper.HashPassword("123"), UserType = UserType.Customer, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new User { Id = 5, Name = "Zeynep Kaya", Email = "zeynep@test.com", Password = PasswordHelper.HashPassword("123"), UserType = UserType.Customer, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Oyuncu Laptop", Price = 35000m, Stock = 15, CategoryId = 1, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Product { Id = 2, Name = "Siyah Tişört", Price = 300m, Stock = 100, CategoryId = 2, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Product { Id = 3, Name = "Kahve Makinesi", Price = 4500m, Stock = 20, CategoryId = 3, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Product { Id = 4, Name = "Dünya Tarihi Kitabı", Price = 150m, Stock = 50, CategoryId = 4, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Product { Id = 5, Name = "Yoga Matı", Price = 600m, Stock = 30, CategoryId = 5, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, OrderNumber = "ORD-001", UserId = 2, Status = OrderStatus.Delivered, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Order { Id = 2, OrderNumber = "ORD-002", UserId = 3, Status = OrderStatus.Pending, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Order { Id = 3, OrderNumber = "ORD-003", UserId = 4, Status = OrderStatus.Shipped, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Order { Id = 4, OrderNumber = "ORD-004", UserId = 5, Status = OrderStatus.Cancelled, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new Order { Id = 5, OrderNumber = "ORD-005", UserId = 2, Status = OrderStatus.Processing, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true }
        );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 35000m, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 1, UnitPrice = 300m, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 4500m, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new OrderItem { Id = 4, OrderId = 3, ProductId = 2, Quantity = 1, UnitPrice = 300m, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true },
            new OrderItem { Id = 5, OrderId = 5, ProductId = 5, Quantity = 1, UnitPrice = 600m, CreatedDate = seedDate, UpdatedDate = seedDate, IsActive = true }
        );
    }
}