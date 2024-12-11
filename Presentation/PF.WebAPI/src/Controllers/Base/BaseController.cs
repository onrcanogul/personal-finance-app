using Microsoft.AspNetCore.Mvc;
using PF.Common.Models.Response;

namespace PF.WebAPI.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected static IActionResult ApiResult<T>(Response<T> response)
        => new ObjectResult(response) { StatusCode = response.StatusCode };
}