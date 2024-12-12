using AutoMapper;
using PF.Application.Abstraction.Activity.Dto;
using PF.Application.Abstraction.Expense.Dto;

namespace PF.Application.Expense.Mapping;

public class ExpenseMapping : Profile
{
    public ExpenseMapping()
    {
        CreateMap<Domain.Entities.Expense, ExpenseDto>().ReverseMap();
        CreateMap<ActivityDto, Domain.Entities.Activity>().ReverseMap();
    }
}