using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.OrderItem;
using MiniECommerce.Business.Interfaces;

namespace MiniECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _orderItemService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _orderItemService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"{id} ID'li sipariş kalemi bulunamadı.");

            return Ok(item);
        }

        // PUT: api/OrderItems
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update([FromBody] OrderItemUpdateDto dto)
        {
            await _orderItemService.UpdateAsync(dto);
            return Ok();
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _orderItemService.GetByIdAsync(id);
            if (item == null)
                return NotFound("Silinmek istenen kayıt bulunamadı.");

            await _orderItemService.DeleteAsync(id);
            return Ok(new { Message = "Sipariş kalemi başarıyla silindi." });
        }
    }
}