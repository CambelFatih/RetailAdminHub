﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Persistence.Contexts;
using RetailAdminHub.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query = Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }
    public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default, bool tracking = true)
    {
        if (!Guid.TryParse(id, out Guid parsedId))      
            throw new InvalidGuidException();      

        var query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data => data.Id == parsedId, cancellationToken);
    }

}

