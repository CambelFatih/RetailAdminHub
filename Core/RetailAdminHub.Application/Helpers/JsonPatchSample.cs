using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace RetailAdminHub.Application.Helpers;
/// <summary>
/// Helper class for retrieving a JSON Patch input formatter.
/// </summary>
public static class MyJPIF
{
    /// <summary>
    /// Gets the JSON Patch input formatter.
    /// </summary>
    /// <returns>The JSON Patch input formatter.</returns>
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        // Create a service collection and configure it.
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();
        // Retrieve the JSON Patch input formatter.
        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}
