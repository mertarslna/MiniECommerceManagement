using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;

namespace MiniECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService, IMapper mapper) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IMapper _mapper = mapper;

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryDtos = await _categoryService.GetAllAsync();
            return Ok(categoryDtos);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null)
                return NotFound(new { Message = "Category not found." });
            var updateDto = _mapper.Map<CategoryUpdateDto>(categoryDto);
            return Ok(updateDto);
        }

        // POST: api/Categories
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto createDto)
        {
            await _categoryService.AddAsync(createDto);
            return Ok(new { Message = "The category has been created successfully." });
        }

        // PUT: api/Categories
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto updateDto)
        {
            await _categoryService.UpdateAsync(updateDto);
            return Ok(new { Message = "Category successfully updated." });
        }

        // DELETE: api/Categories/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { Message = "No category found to delete." });
            await _categoryService.DeleteAsync(id);
            return Ok(new { Message = "Category successfully deleted." });
        }
    }
}