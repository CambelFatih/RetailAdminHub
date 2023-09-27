using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace RetailAdminHub.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddHttpClient();
        }
    }
}
