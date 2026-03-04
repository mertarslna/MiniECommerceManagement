using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoryDtos = _mapper.Map<List<CategoryListDto>>(categories);

            return Ok(categoryDtos);
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(new { Message = "Kategori bulunamadı." });
            }

            var categoryDto = _mapper.Map<CategoryUpdateDto>(category);

            return Ok(categoryDto);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto createDto)
        {
            var categoryEntity = _mapper.Map<Category>(createDto);

            await _categoryService.AddAsync(categoryEntity);

            return Ok(new { Message = "Kategori başarıyla oluşturuldu." });
        }

        // PUT: api/categories
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoryUpdateDto updateDto)
        {
            var existingCategory = await _categoryService.GetByIdAsync(updateDto.Id);

            if (existingCategory == null)
            {
                return NotFound(new { Message = "Güncellenecek kategori bulunamadı." });
            }

            _mapper.Map(updateDto, existingCategory);

            await _categoryService.UpdateAsync(existingCategory);

            return Ok(new { Message = "Kategori başarıyla güncellendi." });
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(new { Message = "Silinecek kategori bulunamadı." });
            }

            await _categoryService.DeleteAsync(category.Id);

            return Ok(new { Message = "Kategori başarıyla silindi." });
        }
    }
}