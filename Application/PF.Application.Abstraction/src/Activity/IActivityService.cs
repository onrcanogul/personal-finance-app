using PF.Application.Abstraction.Activity.Dto;
using PF.Application.src.Abstraction.Base;
using PF.Common.Models.Enums;
using PF.Common.Models.Response;

namespace PF.Application.Abstraction.Activity;

public interface IActivityService : ICrudService<Domain.Entities.Activity, ActivityDto>
{
    Task<Response<List<ActivityDto>>> GetFilteredActivities(ActivityType activityType);
}