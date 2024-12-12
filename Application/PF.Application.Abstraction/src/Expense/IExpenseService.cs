using PF.Application.Abstraction.Expense.Dto;
using PF.Application.src.Abstraction.Base;

namespace PF.Application.Abstraction.Expense;

public interface IExpenseService : ICrudService<Domain.Entities.Expense, ExpenseDto>
{
}