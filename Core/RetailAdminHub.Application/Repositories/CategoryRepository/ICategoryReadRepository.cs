using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.Application.Repositories.CategoryRepository;

public interface ICategoryReadRepository : IReadRepository<Category>
{
    public Task<Category> GetCategoryWithProductsAsync(string categoryId, CancellationToken cancellationToken);
}

