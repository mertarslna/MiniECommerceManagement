using AutoMapper;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Business.DTOs.Order;
using MiniECommerce.Business.DTOs.OrderItem;

namespace MiniECommerce.Business.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderListDto>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<OrderItemUpdateDto, OrderItem>();
            CreateMap<Order, OrderDetailDto>();
            CreateMap<OrderListDto, OrderUpdateDto>();

            // CreateMap<OrderStatusDto, Order>().ReverseMap();
        }
    }

}
