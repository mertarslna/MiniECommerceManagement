using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Interfaces
{
    public interface ICategoryService
    {
        // Adding, listing, updating, deleting and soft deleting functions for categories
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<bool> ToggleActivationAsync(int id);
    }
}