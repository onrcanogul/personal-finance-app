using PF.Application.Abstraction.Budget.Dto;
using PF.Application.src.Abstraction.Base;

namespace PF.Application.Abstraction.Budget;

public interface IBudgetService : ICrudService<Domain.Entities.Budget, BudgetDto>
{
}