using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.API.Extensions.Middleware;
/// <summary>
/// Middleware to extract and set the current user's ID from claims in the HTTP context.
/// </summary>
public class UserContextMiddleware
{
    private readonly RequestDelegate next;

    public UserContextMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    /// <summary>
    /// Invokes the middleware to set the current user's ID based on claims in the HTTP context.
    /// </summary>
    /// <param name="httpContext">The HTTP context.</param>
    /// <param name="dbContext">The application's database context.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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
        await next(httpContext);
    }
}

