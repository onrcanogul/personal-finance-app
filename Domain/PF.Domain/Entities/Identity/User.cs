using Microsoft.AspNetCore.Identity;

namespace PF.Domain.Entities.Identity;

public class User : IdentityUser<string>
{
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiration { get; set; }
    public List<Income> Incomes { get; set; } = new();
    public List<Expense> Expenses { get; set; } = new();
}