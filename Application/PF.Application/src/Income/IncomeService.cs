using AutoMapper;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Income;
using PF.Application.Abstraction.Income.Dto;
using PF.Application.src.Base;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Income;

public class IncomeService(IRepository<Domain.Entities.Income> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer) 
    : CrudService<Domain.Entities.Income, IncomeDto>(repository, mapper, unitOfWork, localizer), IIncomeService
{
    
}