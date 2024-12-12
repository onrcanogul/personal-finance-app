using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Dtos;

namespace PF.Application.Abstraction.Budget.Dto;

public class BudgetDto : BaseDto
{
    public string UserId { get; set; }
    public decimal? TotalIncome => User?.Incomes.Sum(x => x.Price);
    public decimal? TotalExpense => User?.Expenses.Sum(x => x.Price);
    public UserDto? User { get; set; }
}