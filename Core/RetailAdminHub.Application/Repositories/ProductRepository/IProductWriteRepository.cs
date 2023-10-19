using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.Application.Repositories.ProductRepository;

public interface IProductWriteRepository : IWriteRepository<Product>
{
    public Task AddProductWithCategories(Product product, Category categories, CancellationToken cancellationToken);
    public Task<bool> RemoveCategoryProductAsync(string productId, string categoryId);
}

