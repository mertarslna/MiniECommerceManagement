using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        // Adding, listing, updating, deleting and soft deleting functions for categories
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public List<Category> GetAll() => _repository.GetAll();
        public List<Category> GetActiveCategories()
        {
            var categories = _repository.GetAll().Where(c => c.IsActive == true).ToList();
            return categories;
        }
        public Category GetById(int id) => _repository.GetById(id);
        public void Add(Category category)
        {
            category.CreatedDate = DateTime.Now;
            _repository.Add(category);
        }
        public void Update(Category category)
        {
            _repository.Update(category);
        }
        public void Delete(int id)
        {
            var category = _repository.GetById(id);
            if (category != null)
                _repository.Delete(category);
        }
        public bool Deactivate(int id)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                category.IsActive = false;
                _repository.Update(category);
                return true;
            }
            return false;
        }
        public bool Activate(int id)
        {
            var category = _repository.GetById(id);
            if (category != null)
            {
                category.IsActive = true;
                _repository.Update(category);
                return true;
            }
            return false;
        }
    }
}