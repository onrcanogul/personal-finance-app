using AutoMapper;
using PF.Application.Abstraction.Activity.Dto;
using PF.Common.Models.Dtos;
using PF.Common.Models.Entities;

namespace PF.Application.Activity.Mapping;

public class ActivityMapping : Profile
{
    public ActivityMapping()
    {
        CreateMap<Domain.Entities.Activity, ActivityDto>().ReverseMap();
        CreateMap<ActivityDto, Domain.Entities.Activity>().ReverseMap();
        CreateMap<BaseEntity, BaseDto>();
    }
}