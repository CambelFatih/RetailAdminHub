using Microsoft.Extensions.DependencyInjection;
using RetailAdminHub.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Persistence.Repositories.ProductRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Persistence.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Persistence.Repositories.AccountRepository;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Persistence.Uow;

namespace RetailAdminHub.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<RetailAdminHubDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();             
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IAccountReadRepository, AccountReadRepository>();

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<IAccountWriteRepository, AccountWriteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
