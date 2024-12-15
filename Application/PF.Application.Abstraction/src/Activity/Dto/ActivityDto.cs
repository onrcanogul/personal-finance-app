using PF.Common.Models.Dtos;
using PF.Common.Models.Enums;

namespace PF.Application.Abstraction.Activity.Dto;

public class ActivityDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ActivityType Type { get; set; }
}