using AutoMapper;
using Entity.Models;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace GlasySkin.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();

            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<Basket, BasketDto>().ReverseMap(); 
        }
    }
}
