using AutoMapper;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Budget;
using PF.Application.Abstraction.Budget.Dto;
using PF.Application.src.Base;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Budget;

public class BudgetService(IRepository<Domain.Entities.Budget> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer)
    : CrudService<Domain.Entities.Budget, BudgetDto>(repository, mapper, unitOfWork, localizer), IBudgetService
{
    
}