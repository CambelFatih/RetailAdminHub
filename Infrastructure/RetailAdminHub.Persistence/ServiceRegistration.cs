using Microsoft.Extensions.DependencyInjection;
using RetailAdminHub.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Persistence.Uow;

namespace RetailAdminHub.Persistence;

/// <summary>
/// This class contains extension methods to register persistence-related services in the service collection.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Registers the necessary persistence services in the provided <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The service collection to which services will be added.</param>
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // Add DbContext for RetailAdminHubDbContext using Npgsql provider with the connection string from configuration.
        services.AddDbContext<RetailAdminHubDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        // Add UnitOfWork as a scoped service, which is tied to the scope of the HTTP request.
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}

