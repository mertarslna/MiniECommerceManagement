using AutoMapper;
using MiniECommerce.Business.DTOs.User;
using MiniECommerce.Entity.Entities;

namespace MiniECommerce.Business.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, User>().ReverseMap();
        }
    }

}
