using PF.Application.Abstraction.Expense.Dto;
using PF.Application.Abstraction.Income.Dto;

namespace PF.Application.Abstraction.src.User.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public List<IncomeDto> Incomes { get; set; } = new();
    public List<ExpenseDto> Expenses { get; set; } = new();
}