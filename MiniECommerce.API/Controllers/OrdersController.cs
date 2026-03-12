using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Order;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllWithDetailsAsync();
            return Ok(orders);
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdWithDetailsAsync(id);
            if (order == null)
            {
                return NotFound(new { Message = $"Order with ID {id} not found." });
            }

            return Ok(order);
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Update(OrderUpdateDto updateDto)
        {
            var existingOrder = await _orderService.GetByIdAsync(updateDto.Id);
            if (existingOrder == null)
                return NotFound(new { Message = "No order found to update." });

            await _orderService.UpdateAsync(updateDto);
            return NoContent();
        }

        // DELETE: api/order/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
                return NotFound(new { Message = "No order found to delete." });

            await _orderService.DeleteAsync(order.Id);
            return Ok(new { Message = "Order successfully deleted." });
        }
    }
}