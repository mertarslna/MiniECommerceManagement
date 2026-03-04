using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductManager(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<Product>> GetAllWithCategoriesAsync() => await _repository.GetAllWithCategoriesAsync();
        public async Task<Product> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.");

            return await _repository.GetByIdAsync(id);
        }
        public async Task AddAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (product.Price < 0)
                throw new ArgumentException("Product price cant less than zero");
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            _repository.Update(product);
            await _repository.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.");

            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new ArgumentException("Product not found.");

            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }
        public async Task<bool> ToggleActivationAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid product ID.");

            var product = await _repository.GetByIdAsync(id);
            if (product != null)
            {
                product.IsActive = !product.IsActive;
                _repository.Update(product);
                await _repository.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}