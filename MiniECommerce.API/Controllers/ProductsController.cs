using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Product;
using MiniECommerce.Business.Interfaces;

namespace MiniECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productDto = await _productService.GetByIdAsync(id);
            if (productDto == null)
                return NotFound(new { Message = "Product not found." });

            // Güncelleme senaryosu için mapper kullanımı örneği
            var updateDto = _mapper.Map<ProductUpdateDto>(productDto);
            return Ok(updateDto);
        }

        // POST: api/Products
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto createDto)
        {
            await _productService.AddAsync(createDto);
            return Ok(new { Message = "The product has been created successfully." });
        }

        // PUT: api/Products
        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateDto updateDto)
        {
            await _productService.UpdateAsync(updateDto);
            return Ok(new { Message = "Product successfully updated." });
        }

        // DELETE: api/Products/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound(new { Message = "No product found to delete." });

            await _productService.DeleteAsync(id);
            return Ok(new { Message = "Product successfully deleted." });
        }
    }
}