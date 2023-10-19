using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Persistence.Contexts;
using RetailAdminHub.Application.Exceptions;
using System.Linq.Expressions;

namespace RetailAdminHub.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly RetailAdminHubDbContext context;

    public ReadRepository(RetailAdminHubDbContext context)
    {
        this.context = context;
    }

    public DbSet<T> Table => context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true) {
        var query = Table.AsQueryable();
        if(!tracking)
            query= query.AsNoTracking();
        return query;
    }
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.Where(method);
        if(!tracking)
            query = query.AsNoTracking();
        return query;
    }
    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, CancellationToken cancellationToken, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        var result = await query.FirstOrDefaultAsync(method, cancellationToken);
        // Handle the case when no result is found, e.g., throw an exception or return a default value.
        if (result == null)                   
            throw new NotFoundException(); // Adjust the exception type and message accordingly.
 
        return result;
    }
    public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default, bool tracking = true)
    {
        if (!Guid.TryParse(id, out Guid parsedId))      
            throw new InvalidGuidException();      

        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        var result = await query.FirstOrDefaultAsync(data => data.Id == parsedId, cancellationToken);
        if (result == null)
            throw new NotFoundException(); // Adjust the exception type and message accordingly.

        return result;
    }
}

