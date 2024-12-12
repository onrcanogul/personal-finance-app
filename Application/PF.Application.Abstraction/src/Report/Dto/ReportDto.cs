using PF.Application.Abstraction.src.User.Dto;
using PF.Common.Models.Dtos;
using PF.Common.Models.Enums;

namespace PF.Application.Abstraction.Report.Dto;

public class ReportDto : BaseDto
{
    public string UserId { get; set; }
    public UserDto? User { get; set; }
}