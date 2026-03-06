using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
        {
            return await _context.Categories.Where(c => c.IsActive).ToListAsync();
        }
        public async Task<bool> AnyAsync() => await _context.Categories.AnyAsync();
    }
}