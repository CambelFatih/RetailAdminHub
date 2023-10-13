using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.API.Extensions.Middleware;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, RetailAdminHubDbContext dbContext)
    {
        if (httpContext.User?.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = httpContext.User.FindFirst(claim => claim.Type == "Id");
            if (userIdClaim != null)
            {
                if (Guid.TryParse(userIdClaim.Value, out Guid userId))
                {
                    dbContext.CurrentUserId = userId;
                }
            }
        }
        await _next(httpContext);
    }
}

