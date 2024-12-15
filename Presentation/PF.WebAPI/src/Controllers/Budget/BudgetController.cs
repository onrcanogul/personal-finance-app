using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF.Application.Abstraction.Budget;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers.Budget;

public class BudgetController(IBudgetService service) : BaseController
{
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> Get(Guid userId)
        => ApiResult(await service.GetWithUser(userId));
}