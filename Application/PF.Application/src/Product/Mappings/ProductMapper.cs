using AutoMapper;
using PF.Application.src.Abstraction.Dto;
using PF.Common.Models.Dtos;
using PF.Common.Models.Entities;
using PF.Domain.Entities;

namespace PF.Application.src.Mappings;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>()
            .IncludeBase<BaseEntity, BaseDto>();
        CreateMap<ProductDto, Product>()
            .IncludeBase<BaseDto, BaseEntity>();
        CreateMap<BaseEntity, BaseDto>().ReverseMap();
    }
}