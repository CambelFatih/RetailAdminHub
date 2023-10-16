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
    public async Task<bool> RemoveProductCategoryRelationAsync(string productId, string categoryId)
    {
        // Kontroller: productId ve categoryId null değilse ve boş değilse
        if (!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(categoryId))
        {
            string deleteQuery = $"DELETE FROM CategoryProduct WHERE ProductId = '{productId}' AND CategoryId = '{categoryId}'";
            try
            {
                int affectedRows = await context.Database.ExecuteSqlRawAsync(deleteQuery);
                // Sorgu başarılı şekilde çalıştıysa ve en az bir kayıt silindi ise true döndür
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // Hata durumunda false döndür
                return false;
            }
        }

        // productId veya categoryId null veya boşsa, false döndür
        return false;
    }
}

