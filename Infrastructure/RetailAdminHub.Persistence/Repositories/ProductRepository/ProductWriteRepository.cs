using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence.Repositories.ProductRepository;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    readonly private RetailAdminHubDbContext context;
    public ProductWriteRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task AddProductWithCategories(Product product, Category category,CancellationToken cancellationToken)
    {
        // Check if the product's Categories collection is null and create it if necessary
        if (product.Categories == null)
            product.Categories = new List<Category>();
        // Add the category to the product's Categories collection
        product.Categories.Add(category);
        // Save the changes to the database
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> RemoveCategoryProductAsync(string productId, string categoryId)
    {
        // Check if the provided product and category IDs are valid GUIDs
        if (!Guid.TryParse(productId, out Guid pProductId))
            return false;
        if (!Guid.TryParse(categoryId, out Guid pCategoryId))
            return false;
        // Find the product by its ID and include its Categories
        var product = await context.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == pProductId);

        if (product != null)
        {
            // Find the category within the product's Categories collection
            var category = product.Categories.FirstOrDefault(c => c.Id == pCategoryId);

            if (category != null)
            {
                // Remove the category from the product's Categories collection
                product.Categories.Remove(category);
                // Save changes to the database
                int affectedRows = await context.SaveChangesAsync();
                // If at least one row was updated, return true
                return affectedRows > 0;
            }
        }

        // Eğer kayıt bulunamazsa veya kaldırılamazsa false döndür
        return false;
    }

}

