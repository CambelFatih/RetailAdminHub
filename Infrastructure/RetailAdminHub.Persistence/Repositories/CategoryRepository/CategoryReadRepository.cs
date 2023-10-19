using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;
namespace RetailAdminHub.Persistence.Repositories.CategoryRepository;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    private readonly RetailAdminHubDbContext context;
    public CategoryReadRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }
    public async Task<Category> GetCategoryWithProductsAsync(string categoryId, CancellationToken cancellationToken)
    {
        // Check if the provided categoryId is a valid GUID
        if (!Guid.TryParse(categoryId, out Guid parsedId))     
            throw new InvalidGuidException();
        // Retrieve a category with its associated products
        var category = await context.Categories
            .Where(x => x.IsActive)
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == parsedId, cancellationToken);
        // Check if the category was not found and throw an exception
        if (category == null)      
            throw new NotFoundProductException(); // Or another appropriate exception.
       
        return category;
    }
}

