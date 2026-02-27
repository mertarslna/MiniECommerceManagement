using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Interfaces
{
    public interface IProductService
    {
        // Adding, listing, updating, adding image, category selection and deleting functions for products
        List<Product> GetAll();
        List<Product> GetAllWithCategories();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        bool Activate(int id);
        bool Deactivate(int id);
    }
}