using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace RetailAdminHub.API.Extensions.Middleware;
/// <summary>
/// Resource filter for logging resource-related actions.
/// </summary>
public class LogResourceFilter : IResourceFilter
{
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        Log.Information("LogResourceFilter.OnResourceExecuted");
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        Log.Information("LogResourceFilter.OnResourceExecuting");
    }
}
/// <summary>
/// Action filter for logging action-related actions.
/// </summary>
public class LogActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        Log.Information("LogActionFilter.OnActionExecuted");
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Log.Information("LogActionFilter.OnActionExecuting");
    }
}

public class LogAuthorizationFilter : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        Log.Information("LogAuthorizationFilter.OnAuthorization");
    }
}

public class LogResultFilter : IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {
        Log.Information("LogResultFilter.OnResultExecuted");
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {
        Log.Information("LogResultFilter.OnResultExecuting");
    }
}
/// <summary>
/// Exception filter for logging exceptions.
/// </summary>
public class LogExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        Log.Information("LogExceptionFilter.OnException");
    }
}
