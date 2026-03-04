using AutoMapper;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Business.DTOs.Product;

namespace MiniECommerce.Business.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListDto>();

            CreateMap<ProductCreateDto, Product>();

            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }

}
