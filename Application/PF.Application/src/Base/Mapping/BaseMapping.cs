using AutoMapper;
using PF.Application.Abstraction.Activity.Dto;
using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Dtos;
using PF.Common.Models.Entities;
using PF.Domain.Entities.Identity;

namespace PF.Application.src.Base.Mapping;

public class BaseMapping : Profile
{
    public BaseMapping()
    {
        CreateMap<BaseEntity, BaseDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Domain.Entities.Activity, ActivityDto>().IncludeBase<BaseEntity, BaseDto>().ReverseMap();
        CreateMap<ActivityDto, Domain.Entities.Activity>().IncludeBase<BaseDto, BaseEntity>().ReverseMap();
    }
}