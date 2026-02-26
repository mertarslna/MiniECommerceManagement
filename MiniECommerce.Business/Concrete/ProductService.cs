using MiniECommerce.Business.Services.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Services.Concrete
{
    public class ProductService : IProductService
    {
        // Adding, listing, updating, adding image, category selection and deleting functions for products
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public List<Product> GetAll() { return _repository.GetAll(); }
        public Product GetById(int id) { return _repository.GetById(id); }
        public void Add(Product product)
        {
            product.CreatedDate = DateTime.Now;
            _repository.Add(product);
        }
        public List<Product> GetAllWithCategories() { return _repository.GetProductsWithCategories(); }
        public void Update(Product product) { _repository.Update(product); }
        public bool UpdateImage(int id, string imageUrl)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                product.ImageUrl = imageUrl;
                _repository.Update(product);
                return true;
            }
            return false;
        }
        public bool UpdateCategory(int id, int categoryId)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                product.CategoryId = categoryId;
                _repository.Update(product);
                return true;
            }
            return false;
        }
        public void Delete(int id) { _repository.Delete(_repository.GetById(id)); }
        public bool Activate(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                product.IsActive = true;
                _repository.Update(product);
                return true;
            }
            return false;
        }

        public bool Deactivate(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                product.IsActive = false;
                _repository.Update(product);
                return true;
            }
            return false;
        }
    }
}