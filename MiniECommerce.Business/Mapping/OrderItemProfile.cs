using AutoMapper;
using MiniECommerce.Business.DTOs.OrderItem;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Mapping
{
    public class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemListDto>();

            CreateMap<OrderItemUpdateDto, OrderItem>().ReverseMap();

            CreateMap<OrderItem, OrderItemUpdateDto>();
        }
    }
}