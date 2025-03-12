namespace WebApi.Helpers;

using AutoMapper;
using WebApis.Models.Dtos;
using WebApis.Models.Entities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
  
        CreateMap<CreateUser, User>();
         CreateMap<User, UserResponse>();
         CreateMap<CreateProduct, Product>()
            .ForMember(dest => dest.ProductDetail, opt => opt.MapFrom(src => src.ProductDetail));


        CreateMap<ProductDetailDTO, ProductDetail>();
    }
}