using Microsoft.Extensions.DependencyInjection;
using RetailAdminHub.Application.Abstractions;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Concretes;
using RetailAdminHub.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Persistence.Repositories;

namespace RetailAdminHub.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddDbContext<RetailAdminHubDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
