using RetailAdminHub.Domain.Entities;

namespace RetailAdminHub.Application.Repositories.ProductRepository;

public interface IProductReadRepository : IReadRepository<Product>
{
    public Task<Product>? GetProductWithCategoriesAsync(string productId , CancellationToken cancellationToken);
    public Task<List<Product>> GetProductsPagedWithCategoriesAsync(int page, int size, CancellationToken cancellationToken);
}

