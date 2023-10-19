using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RetailAdminHub.Application.Validators;

namespace RetailAdminHub.Application;
/// <summary>
/// A class responsible for registering application services.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Adds application services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which services will be added.</param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Register MediatR services from the assembly containing this class.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        // Add HttpClient services.
        services.AddHttpClient();
        // Configure FluentValidation for request validation.
        // Register FluentValidation auto-validation for ASP.NET Core.
        services.AddFluentValidationAutoValidation();
        // Register validators from the assembly containing BaseValidator.
        services.AddValidatorsFromAssemblyContaining<BaseValidator>();
    }
}

