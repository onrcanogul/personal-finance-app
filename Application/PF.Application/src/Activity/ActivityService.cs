using AutoMapper;
using Microsoft.Extensions.Localization;
using PF.Application.Abstraction.Activity;
using PF.Application.Abstraction.Activity.Dto;
using PF.Application.src.Base;
using PF.Persistence.Repository;
using PF.Persistence.UnitOfWork;

namespace PF.Application.Activity;

public class ActivityService(IRepository<Domain.Entities.Activity> repository, IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer localizer) 
    : CrudService<Domain.Entities.Activity, ActivityDto>(repository, mapper, unitOfWork, localizer), IActivityService
{
}