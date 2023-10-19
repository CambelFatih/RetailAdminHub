using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities.Common;

namespace RetailAdminHub.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}

