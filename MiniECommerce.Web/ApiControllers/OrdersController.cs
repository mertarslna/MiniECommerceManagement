using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Order;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/order
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();
            var orderDtos = _mapper.Map<List<OrderListDto>>(orders);
            return Ok(orderDtos);
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            var orderDto = _mapper.Map<OrderDetailDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderUpdateDto orderUpdateDto)
        {
            var order = _mapper.Map<Order>(orderUpdateDto);
            await _orderService.AddAsync(order);

            return CreatedAtAction(nameof(GetById), new { id = order.Id }, orderUpdateDto);
        }

        // PUT: api/order/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderUpdateDto orderUpdateDto)
        {
            var existingOrder = await _orderService.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound("Güncellenecek sipariş bulunamadı.");
            }

            _mapper.Map(orderUpdateDto, existingOrder);

            await _orderService.UpdateAsync(existingOrder);
            return NoContent();
        }

        // DELETE: api/order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound("Silinecek sipariş bulunamadı.");
            }

            await _orderService.DeleteAsync(order.Id);
            return Ok("Sipariş başarıyla silindi.");
        }
    }
}