using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Domain.Entities.Common;
namespace RetailAdminHub.Persistence.Contexts;
/// <summary>
/// DbContext for RetailAdminHub application, representing the database context.
/// </summary>
public class RetailAdminHubDbContext : DbContext
{
    /// <summary>
    /// Gets or sets the current user's ID for context tracking.
    /// </summary>
    public Guid CurrentUserId { get; set; } = Guid.Empty;
    /// <summary>
    /// Initializes a new instance of the <see cref="RetailAdminHubDbContext"/> class.
    /// </summary>
    /// /// <param name="options">The options to be used by the context.</param>
    public RetailAdminHubDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var data in datas)
        {
            switch (data.State)
            {
                case EntityState.Added:
                    data.Entity.InsertDate = DateTime.UtcNow;
                    data.Entity.InsertUserId = CurrentUserId;
                    data.Entity.IsActive = true;
                    break;
                case EntityState.Modified:
                    data.Entity.UpdateDate = DateTime.UtcNow;
                    data.Entity.UpdateUserId = CurrentUserId;
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}

