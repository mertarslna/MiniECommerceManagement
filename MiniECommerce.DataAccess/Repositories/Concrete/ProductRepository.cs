using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetAllWithCategoriesAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<Product> GetByIdWithCategoriesAsync(int id)
        {
            return await _context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .FirstOrDefaultAsync();
        }
    }
}
