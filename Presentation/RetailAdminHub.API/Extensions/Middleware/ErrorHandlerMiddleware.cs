﻿using RetailAdminHub.Domain.Response;
using System.Net;
using System.Text.Json;
using Serilog;

namespace RetailAdminHub.API.Extensions.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Log.Information("LogErrorHandlerMiddleware.Invoke");
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            Log.Fatal(
                $"Path={context.Request.Path} || " +
                $"Method={context.Request.Method} || " +
                $"Exception={ex.Message}"
            );
            ApiResponse response = new ApiResponse("Internal Server Error");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
