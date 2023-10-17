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
        if (product.Categories == null)
            product.Categories = new List<Category>();  // Koleksiyonu oluştur
        product.Categories.Add(category);
        await context.SaveChangesAsync(cancellationToken);
    }
    public async Task<bool> RemoveCategoryProductAsync(string productId, string categoryId)
    {

        if (!Guid.TryParse(productId, out Guid pProductId))
        {
            return false;
        }
        if (!Guid.TryParse(categoryId, out Guid pCategoryId))
        {
            return false;
        }

        // Product'ı bul
        var product = await context.Products
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == pProductId);

        if (product != null)
        {
            // Category'yi bul
            var category = product.Categories.FirstOrDefault(c => c.Id == pCategoryId);

            if (category != null)
            {
                // Category'yi Product'tan kaldır
                product.Categories.Remove(category);
                int affectedRows = await context.SaveChangesAsync();

                // Eğer en az bir satır güncellendi ise true döndür
                return affectedRows > 0;
            }
        }

        // Eğer kayıt bulunamazsa veya kaldırılamazsa false döndür
        return false;
    }

}

