using AutoMapper;
using PF.Application.Abstraction.Budget.Dto;

namespace PF.Application.Budget.Mapping;

public class BudgetMapping : Profile
{
    public BudgetMapping()
    {
        CreateMap<Domain.Entities.Budget, BudgetDto>();
    }
}