using RetailAdminHub.Domain.Entities.Common;
using System.Linq.Expressions;


namespace RetailAdminHub.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking=true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>>method, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, CancellationToken cancellationToken, bool tracking = true);
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default, bool tracking = true);
}

