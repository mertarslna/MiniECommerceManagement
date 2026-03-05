using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase // Primary Constructor
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryDtos = await _categoryService.GetAllAsync();
            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);

            if (categoryDto == null)
                return NotFound(new { Message = "Kategori bulunamadı." });

            var updateDto = _mapper.Map<CategoryUpdateDto>(categoryDto);
            return Ok(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto createDto)
        {
            await _categoryService.AddAsync(createDto);
            return Ok(new { Message = "Kategori başarıyla oluşturuldu." });
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto updateDto)
        {
            await _categoryService.UpdateAsync(updateDto);
            return Ok(new { Message = "Kategori başarıyla güncellendi." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { Message = "Silinecek kategori bulunamadı." });

            await _categoryService.DeleteAsync(id);
            return Ok(new { Message = "Kategori başarıyla silindi." });
        }
    }
}