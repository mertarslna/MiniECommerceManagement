using MiniECommerce.Business.DTOs.Product;

namespace MiniECommerce.Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListDto>> GetAllAsync();
        Task<ProductListDto> GetByIdAsync(int id);
        Task AddAsync(ProductCreateDto dto);
        Task UpdateAsync(ProductUpdateDto dto);
        Task DeleteAsync(int id);
        Task<bool> ToggleActivationAsync(int id);
    }
}