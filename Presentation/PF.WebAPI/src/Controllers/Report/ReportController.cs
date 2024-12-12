using Microsoft.AspNetCore.Mvc;
using PF.Application.Abstraction.Report;
using PF.Common.Models.Enums;
using PF.WebAPI.Controllers.Base;

namespace PF.WebAPI.Controllers.Report;

public class ReportController(IReportService service) : BaseController
{
    [HttpGet("{userId:guid}/{reportType:int}")]
    public async Task<IActionResult> Get([FromRoute] Guid userId, [FromRoute] int reportType) 
        => ApiResult(await service.Get(userId, (ReportType)reportType));
}