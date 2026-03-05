using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniECommerce.Business.DTOs.Category;
using MiniECommerce.Business.Interfaces;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Web.ApiControllers
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

    }
}