using Microsoft.EntityFrameworkCore;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Entity.Enums;

namespace MiniECommerce.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        // DbSet Properties
        // Categories dbset'i ekleyelim
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product -> Category (N - 1)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Order -> User (N - 1)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            // OrderItem -> Order (N - 1)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // OrderItem -> Product (N - 1)
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // Decimal Precisions
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2);

            // Mock Datas
            DateTime seedDate = DateTime.Now;

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik", IsActive = true, CreatedDate = seedDate },
                new Category { Id = 2, Name = "Giyim", IsActive = true, CreatedDate = seedDate }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Mert Arslan", Email = "mert@admin.com", Password = "123", UserType = UserTypes.Administrator },
                new User { Id = 2, Name = "Standart Müşteri", Email = "musteri@test.com", Password = "123", UserType = UserTypes.Customer }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Oyuncu Laptop", Price = 35000, Stock = 15, CategoryId = 1, IsActive = true, CreatedDate = seedDate },
                new Product { Id = 2, Name = "Siyah Tişört", Price = 300, Stock = 100, CategoryId = 2, IsActive = true, CreatedDate = seedDate }
            );
        }
    }
}