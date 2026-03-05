using AutoMapper;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.DataAccess.Repositories.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Concrete
{
    public class CategoryManager(ICategoryRepository repository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CategoryListDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryListDto>>(categories);
        }

        public async Task<IEnumerable<CategoryListDto>> GetActiveCategoriesAsync()
        {
            var categories = await _repository.GetActiveCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryListDto>>(categories);
        }

        public async Task<CategoryListDto?> GetByIdAsync(int id)
        {
            if (id <= 0) return null;
            var category = await _repository.GetByIdAsync(id);

            return _mapper.Map<CategoryListDto>(category);
        }

        public async Task AddAsync(CategoryCreateDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            category.IsActive = true;
            category.CreatedDate = DateTime.Now;

            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryUpdateDto dto)
        {
            var existingCategory = await _repository.GetByIdAsync(dto.Id);
            if (existingCategory is null) throw new Exception("Kategori bulunamadı.");

            _mapper.Map(dto, existingCategory);

            _repository.Update(existingCategory);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is not null)
            {
                _repository.Delete(category);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ToggleActivationAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null) return false;

            category.IsActive = !category.IsActive;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}