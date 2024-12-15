using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Activity;
using PF.Application.Abstraction.Activity.Dto;
using PF.Application.src.Base;
using PF.Common.Models.Enums;
using PF.Common.Models.Response;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Activity;

public class ActivityService(IRepository<Domain.Entities.Activity> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer) 
    : CrudService<Domain.Entities.Activity, ActivityDto>(repository, mapper, unitOfWork, localizer), IActivityService
{
    public async Task<Response<List<ActivityDto>>> GetFilteredActivities(ActivityType activityType)
    {
        var activities = await repository.GetListAsync(predicate: SetPredicate(activityType));
        var dto = mapper.Map<List<Domain.Entities.Activity>, List<ActivityDto>>(activities);
        return Response<List<ActivityDto>>.Success(dto, StatusCodes.Status200OK);
    }

    private Expression<Func<Domain.Entities.Activity?, bool>>? SetPredicate(ActivityType type)
    {
        return type switch
        {
            ActivityType.Income => activity => activity.Type == ActivityType.Income,
            ActivityType.Expense => activity => activity.Type == ActivityType.Expense,
            _ => activity => true,
        };
    }
}