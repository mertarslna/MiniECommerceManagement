using AutoMapper;
using MiniECommerce.Business.DTOs.Product;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");
            _repository.Delete(product);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductListDto>> GetAllAsync()
        {
            var products = await _repository.GetAllWithCategoriesAsync();
            return _mapper.Map<IEnumerable<ProductListDto>>(products);
        }

        public async Task<ProductListDto> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdWithCategoriesAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            return _mapper.Map<ProductListDto>(product);
        }

        public async Task<bool> ToggleActivationAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found.");

            _repository.ToggleActivation(product);
            await _repository.SaveChangesAsync();
            return product.IsActive;
        }

        public async Task UpdateAsync(ProductUpdateDto dto)
        {
            var existingProduct = await _repository.GetByIdAsync(dto.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException("Product not found.");

            _mapper.Map(dto, existingProduct);
            _repository.Update(existingProduct);
            await _repository.SaveChangesAsync();
        }
    }
}