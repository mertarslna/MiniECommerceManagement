using AutoMapper;
using MiniECommerce.Entity.Entities;
using MiniECommerce.Business.DTOs.Category;

namespace MiniECommerce.Business.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryListDto, CategoryUpdateDto>().ReverseMap();
        }
    }

}
