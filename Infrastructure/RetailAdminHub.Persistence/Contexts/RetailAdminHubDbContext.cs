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

    }
}
