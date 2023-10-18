using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence;
/// <summary>
/// Factory for creating the application's DbContext at design time.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RetailAdminHubDbContext>
{
    /// <summary>
    /// Creates an instance of RetailAdminHubDbContext for design-time tools like migrations.
    /// </summary>
    /// <param name="args">Command-line arguments, if any.</param>
    /// <returns>An instance of RetailAdminHubDbContext for design-time usage.</returns>
    public RetailAdminHubDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<RetailAdminHubDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
        // Return a new instance of the RetailAdminHubDbContext using the specified options.
        return new(dbContextOptionsBuilder.Options);
    }
}

