﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Domain.Entities.Common;
namespace RetailAdminHub.Persistence.Contexts;

public class RetailAdminHubDbContext : DbContext
{
    public Guid CurrentUserId { get; set; } = Guid.Empty;
    public RetailAdminHubDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<CategoryProduct> CategoryProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CategoryProduct entity tipinin birincil anahtarı olmadığını belirt
        modelBuilder.Entity<CategoryProduct>().HasNoKey();

        // Diğer entity tiplerinin konfigürasyonları burada yapılabilir
    }
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

