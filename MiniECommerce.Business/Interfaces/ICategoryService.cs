using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Interfaces
{
    public interface ICategoryService
    {
        // Adding, listing, updating, deleting and soft deleting functions for categories
        Task<IEnumerable<CategoryListDto>> GetAllAsync();
        Task<IEnumerable<CategoryListDto>> GetActiveCategoriesAsync();
        Task<CategoryListDto?> GetByIdAsync(int id);
        Task AddAsync(CategoryCreateDto dto);
        Task UpdateAsync(CategoryUpdateDto dto);
        Task DeleteAsync(int id);
        Task<bool> ToggleActivationAsync(int id);
    }
}