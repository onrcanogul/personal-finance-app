using PF.Common.Models.Entities;
using PF.Domain.Entities.Identity;

namespace PF.Domain.Entities;

public class Budget : BaseEntity
{
    public string UserId { get; set; }
    public decimal? TotalIncome => User?.Incomes.Sum(x => x.Price);
    public decimal? TotalExpense => User?.Expenses.Sum(x => x.Price);
    public User? User { get; set; }
}