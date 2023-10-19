using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly RetailAdminHubDbContext context;

    public WriteRepository(RetailAdminHubDbContext context)
    {
        this.context = context;
    }
    // Access the DbSet for the specified entity
    public DbSet<T> Table => context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
        // Add the entity to the DbSet asynchronously
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        // Check if the entity has been marked as added
        return entityEntry.State == EntityState.Added;
    }
    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        // Add a range of entities to the DbSet asynchronously
        await Table.AddRangeAsync(datas);
        // Check if the entity has been marked as added
        return true;
    }
    public bool Remove(T model)
    {
        // Remove the entity from the DbSet
        EntityEntry<T> entityEntry = Table.Remove(model);
        // Check if the entity has been marked as deleted
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<T> datas)
    {
        // Remove a range of entities from the DbSet
        Table.RemoveRange(datas);
        // Always return true after removing a range
        return true;
    }
    public async Task<bool> RemoveAsync(string id)
    {
        // Check if the provided ID is a valid GUID
        if (!Guid.TryParse(id, out Guid parsedId))
            return false;
        T model = await Table.FirstOrDefaultAsync(data => data.Id == parsedId);
        if (model == null)
            return false;
        return Remove(model);            
    }
    public bool Update(T model)
    {
        EntityEntry entityEntry =  Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }
    public async Task<bool> SoftDeleteById(string entityId, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(entityId, out Guid parsedId))       
            return false;
        
        var entity = await Table.FirstOrDefaultAsync(x => x.Id == parsedId, cancellationToken);
        // Check if the entity exists, mark it as inactive, and save the changes
        if (entity == null)
            return false;
        
        entity.IsActive = false;
        await context.SaveChangesAsync(cancellationToken);
        // Return true to indicate a successful soft delete
        return true; 
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        // Save changes in the context and return the number of affected rows
        return await context.SaveChangesAsync(cancellationToken);
    }
}
