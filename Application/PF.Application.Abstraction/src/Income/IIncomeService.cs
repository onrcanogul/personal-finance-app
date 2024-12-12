using PF.Application.Abstraction.Income.Dto;
using PF.Application.src.Abstraction.Base;

namespace PF.Application.Abstraction.Income;

public interface IIncomeService : ICrudService<Domain.Entities.Income, IncomeDto>
{
}