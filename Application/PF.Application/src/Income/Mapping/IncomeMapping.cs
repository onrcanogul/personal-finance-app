using AutoMapper;
using PF.Application.Abstraction.Income.Dto;

namespace PF.Application.Income.Mapping;

public class IncomeMapping : Profile
{
    public IncomeMapping()
    {
        CreateMap<Domain.Entities.Income, IncomeDto>().ReverseMap();   
    }
}