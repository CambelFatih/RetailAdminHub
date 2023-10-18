using System.Net;
using System.Text.Json;
using Serilog;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.API.Extensions.Middleware;
/// <summary>
/// Middleware for handling errors and generating appropriate responses.
/// </summary>
public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    /// <summary>
    /// Invokes the error handling middleware to handle exceptions and generate error responses.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    public async Task Invoke(HttpContext context)
    {
        Log.Information("LogErrorHandlerMiddleware.Invoke");
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            // Note: In production, it's best practice to avoid exposing exception messages directly to users for security reasons.
            // Logging the error is sufficient, and exposing detailed error messages to users could potentially pose a security risk.

            // Example for logging the error and not exposing the exception message to the user:
            // ApiResponse response = new ApiResponse("An unexpected error occurred. Please try again later.");

            // Log the exception details
            Log.Fatal(
                $"Path={context.Request.Path} || " +
                $"Method={context.Request.Method} || " +
                $"Exception={ex.Message}"
            );
            // Create an error response with the exception message
            ApiResponse response = new ApiResponse("An unexpected error occurred. Please try again later.");//"Internal Server Error"
             // Set the HTTP status code to 500 (Internal Server Error)
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            // Serialize the response as JSON and write it to the response
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

