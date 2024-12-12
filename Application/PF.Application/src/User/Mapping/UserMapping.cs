using AutoMapper;
using PF.Application.Abstraction.src.User.Dto;
using PF.Domain.Entities.Identity;

namespace PF.Application.src.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}