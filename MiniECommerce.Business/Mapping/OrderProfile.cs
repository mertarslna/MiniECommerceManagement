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

            CreateMap<Order, OrderDetailDto>();

            CreateMap<Order, OrderItemListDto>();

            // CreateMap<OrderStatusDto, Order>().ReverseMap();
        }
    }

}
