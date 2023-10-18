using Serilog;
using System.Text.Json;

namespace RetailAdminHub.API.Extensions.Middleware
{
    /// <summary>
    /// Middleware to handle heartbeat requests and respond with a heartbeat message.
    /// </summary>
    public class HeartBeatMiddleware
    {
        private readonly RequestDelegate next;

        public HeartBeatMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        /// <summary>
        /// Invokes the heartbeat middleware to handle requests and respond with a heartbeat message.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        public async Task Invoke(HttpContext context)
        {
            Log.Information("HeartBeat");
            // Check if the request path starts with "/hello"
            if (context.Request.Path.StartsWithSegments("/hello"))
            {
                // Respond with a simple message indicating the server is running
                await context.Response.WriteAsync(JsonSerializer.Serialize("Hello from server!"));
                // Set the HTTP status code to 200 (OK)
                context.Response.StatusCode = 200;
                return;
            }
            // Continue processing the request
            await next.Invoke(context);
        }
    }
}
