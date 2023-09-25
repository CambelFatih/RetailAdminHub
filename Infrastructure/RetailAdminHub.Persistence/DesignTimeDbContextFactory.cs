using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RetailAdminHub.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RetailAdminHubDbContext>
    {
        public RetailAdminHubDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RetailAdminHubDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
