using Microsoft.AspNetCore.Mvc;
using PF.Application.Abstraction.Activity;
using PF.Application.Abstraction.Activity.Dto;
using PF.Common.Models.Enums;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers.Activity;

public class ActivityController(IActivityService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get(int page = 1, int pageSize = 20) 
        => ApiResult(await service.GetPagedListAsync(page, pageSize));
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
        => ApiResult(await service.GetFirstOrDefaultAsync(x => x.Id == id));

    [HttpGet("{activityType:int}")]
    public async Task<IActionResult> GetByActivityType([FromRoute]int activityType)
        => ApiResult(await service.GetFilteredActivities((ActivityType)activityType));
    
    [HttpPost]
    public async Task<IActionResult> Create(ActivityDto activity)
        => ApiResult(await service.CreateAsync(activity));
    
    [HttpPut]
    public async Task<IActionResult> Update(ActivityDto activity)
        => ApiResult(await service.UpdateAsync(activity));
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => ApiResult(await service.DeleteAsync(id));
}