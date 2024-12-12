using PF.Common.Models.Dtos;

namespace PF.Application.Abstraction.Activity.Dto;

public class ActivityDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}