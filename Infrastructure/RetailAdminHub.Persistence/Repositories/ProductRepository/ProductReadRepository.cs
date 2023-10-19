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
        // Check if the provided productId is a valid GUID
        if (!Guid.TryParse(productId, out Guid parsedId))        
            throw new InvalidGuidException();
        
        var product = await context.Products
            .Where(x => x.IsActive)
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == parsedId, cancellationToken);
        // Check if the product was not found and throw an exception      
        if (product == null)      
            throw new NotFoundProductException(); // Or return a default product.
        // You can throw an exception or return a default value.
        return product;
    }
    public async Task<List<Product>> GetProductsPagedWithCategoriesAsync(int page, int size, CancellationToken cancellationToken)
    {
        // Retrieve a paged list of products with their associated categories
        return await context.Products
                                .Where(x => x.IsActive)
                                .Include(p => p.Categories)
                                .Skip(page * size)
                                .Take(size)
                                .ToListAsync(cancellationToken);
    }
}

