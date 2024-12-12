using PF.Application.Abstraction.Activity.Dto;
using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Dtos;

namespace PF.Application.Abstraction.Income.Dto;

public class IncomeDto : BaseDto
{
    public string UserId { get; set; } = null!;
    public Guid ActivityId { get; set; }
    public decimal Price { get; set; }

    public ActivityDto? Activity { get; set; }
    public UserDto? User { get; set; }
}