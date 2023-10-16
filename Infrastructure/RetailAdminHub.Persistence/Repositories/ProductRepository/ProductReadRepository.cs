using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence.Repositories.ProductRepository;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    readonly private RetailAdminHubDbContext context;
    public ProductReadRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }
    public async Task<Product>? GetProductWithCategoriesAsync(string productId, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(productId, out Guid parsedId))
        {
            throw new InvalidGuidException();
        }
        return await context.Products
            .Where(x => x.IsActive)
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == parsedId, cancellationToken);
    }
    public async Task<List<Product>> GetProductsPagedWithCategoriesAsync(int page, int size)
    {
        return await context.Products
                                .Where(x => x.IsActive)
                                .Include(p => p.Categories)
                                .Skip(page * size)
                                .Take(size)
                                .ToListAsync();
    }

}

