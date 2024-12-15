using PF.Application.Abstraction.Budget.Dto;
using PF.Application.src.Abstraction.Base;
using PF.Common.Models.Response;

namespace PF.Application.Abstraction.Budget;

public interface IBudgetService : ICrudService<Domain.Entities.Budget, BudgetDto>
{
    Task<Response<BudgetDto>> GetWithUser(Guid userId);
}