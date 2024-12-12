using PF.Application.Abstraction.Activity.Dto;
using PF.Application.src.Abstraction.Base;

namespace PF.Application.Abstraction.Activity;

public interface IActivityService : ICrudService<Domain.Entities.Activity, ActivityDto>
{
}