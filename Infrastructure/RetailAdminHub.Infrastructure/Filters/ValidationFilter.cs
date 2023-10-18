using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RetailAdminHub.Infrastructure.Filters;
/// <summary>
/// Action filter to validate the model state of a request.
/// </summary>
public class ValidationFilter : IAsyncActionFilter
{
    /// <summary>
    /// Handles the action execution asynchronously.
    /// </summary>
    /// <param name="context">The action executing context.</param>
    /// <param name="next">The action execution delegate.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(!context.ModelState.IsValid)
        {
            // Retrieve validation errors from the model state.
            var errors =context.ModelState
                .Where(x=> x.Value.Errors.Any())
                .ToDictionary(e=>e.Key, e => e.Value.Errors.Select(e => e.ErrorMessage)).ToArray();
            // Set the response to a BadRequestObjectResult containing the validation errors.
            context.Result=new BadRequestObjectResult(errors);

        }
        await next();
    }
}

