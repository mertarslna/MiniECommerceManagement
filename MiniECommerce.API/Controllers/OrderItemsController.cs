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

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
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
                return NotFound($"Order item with ID {id} not found.");

            return Ok(item);
        }

        // PUT: api/OrderItems
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(OrderItemUpdateDto updateDto)
        {
            await _orderItemService.UpdateAsync(updateDto);
            return Ok();
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderItem = await _orderItemService.GetByIdAsync(id);
            if (orderItem == null)
                return NotFound($"No order item found with ID {id} to delete.");

            await _orderItemService.DeleteAsync(id);
            return Ok(new { Message = "Order item successfully deleted." });
        }
    }
}