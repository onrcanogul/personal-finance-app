using PF.Application.Abstraction.Activity.Dto;
using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Dtos;

namespace PF.Application.Abstraction.Expense.Dto;

public class ExpenseDto : BaseDto
{
    public string UserId { get; set; }
    public Guid ActivityId { get; set; }
    public decimal Price { get; set; }
    public bool IsPaid { get; set; }

    public ActivityDto? Activity { get; set; }
    public UserDto? User { get; set; }
}