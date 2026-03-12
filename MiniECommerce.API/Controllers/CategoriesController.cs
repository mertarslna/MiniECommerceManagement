using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;

namespace MiniECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categorieservice)
        {
            _categoryService = categorieservice;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryDtos = await _categoryService.GetAllAsync();
            return Ok(categoryDtos);
        }

        // GET: api/Categories/5}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            if (categoryDto == null)
                return NotFound(new { Message = $"Category with ID {id} not found." });

            return Ok(categoryDto);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CategoryUpdateDto updateDto)
        {
            var existingOrder = await _categoryService.GetByIdAsync(updateDto.Id);
            if (existingOrder == null)
                return NotFound(new { Message = $"No order found with ID {updateDto.Id} to update." });

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
                return NotFound(new { Message = $"No category found with ID {id} to delete." });

            await _categoryService.DeleteAsync(id);
            return Ok(new { Message = "Category successfully deleted." });
        }
    }
}