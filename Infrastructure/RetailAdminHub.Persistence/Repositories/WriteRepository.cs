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
    public DbSet<T> Table => context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }
    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }
    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }
    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }
    public async Task<bool> RemoveAsync(string id)
    {
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
        if (entity == null)
            return false;
        
        entity.IsActive = false;
        await context.SaveChangesAsync(cancellationToken);
        return true; 
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}
