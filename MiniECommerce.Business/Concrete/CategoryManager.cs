using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryManager(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync() => await _repository.GetActiveCategoriesAsync();

        public async Task<Category?> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid category ID.", nameof(id));

            var category = await _repository.GetByIdAsync(id);

            return category;
        }

        public async Task AddAsync(Category category)
        {
            if (category.Name == null || category.Name.Trim() == "")
                throw new Exception("Category name cannot be empty.");

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            if (category == null || category.Id <= 0)
                throw new Exception("Invalid category.");

            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
                throw new ArgumentException("Category not found.");

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }

        public async Task<bool> ToggleActivationAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                category.IsActive = !category.IsActive;
                _repository.Update(category);
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}