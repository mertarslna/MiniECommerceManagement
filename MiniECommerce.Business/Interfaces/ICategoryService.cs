using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        // Adding, listing, updating, deleting and soft deleting functions for categories
        List<Category> GetAll();
        List<Category> GetActiveCategories();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        bool Deactivate(int id);
        bool Activate(int id);
    }
}