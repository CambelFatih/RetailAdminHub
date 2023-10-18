using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RetailAdminHub.Application.Validators;

namespace RetailAdminHub.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
            services.AddHttpClient();

            // Configure FluentValidation for request validation

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<BaseValidator>();
        }
    }
}
