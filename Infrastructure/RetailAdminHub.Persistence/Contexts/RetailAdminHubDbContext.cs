using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence.Contexts
{
    public class RetailAdminHubDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public RetailAdminHubDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // ChangeTracker: A property that allows for the capturing of changes made on entities or newly added data. It enables us to capture and retrieve the tracked data during update operations.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        // You can also set UpdatedDate on initial creation, optional.
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        // In case of change, only UpdatedDate should be updated.
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
