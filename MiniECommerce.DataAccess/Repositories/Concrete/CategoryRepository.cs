using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        protected readonly DbSet<Category> _dbSet;
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}