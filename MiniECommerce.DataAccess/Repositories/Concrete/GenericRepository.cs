using Microsoft.EntityFrameworkCore;
using MiniECommerce.DataAccess.Context;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.DataAccess.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // CRUD operations
        // Create, Read, Update, Delete
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public void Update(T entity) => _dbSet.Update(entity);
        public void ToggleActivation(T entity)
        {
            entity.IsActive = !entity.IsActive;
            _dbSet.Update(entity);
        }
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}