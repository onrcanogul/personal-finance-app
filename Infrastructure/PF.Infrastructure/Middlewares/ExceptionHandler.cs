using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using PF.Common.Exceptions;
using PF.Common.Models.Response;

namespace PF.Infrastructure.Middlewares;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = exception switch
        {
            NotFoundException => 404,
            BadRequestException => 400,
            UnauthorizedException => 401,
            ForbiddenException => 403,
            _ => 500
        };

        var response = Response<NoContent>.Failure(exception.Message, httpContext.Response.StatusCode);
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
        return true;
    }
}
