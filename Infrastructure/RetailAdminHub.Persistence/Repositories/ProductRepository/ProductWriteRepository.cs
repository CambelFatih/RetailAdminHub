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
        try
        {
            if (!Guid.TryParse(productId, out Guid pProductId))
            {
                return false;
            }
            if (!Guid.TryParse(categoryId, out Guid pCategoryId))
            {
                return false;
            }
            // CategoryProduct tablosundan ilgili kaydı bul
            var categoryProduct = await context.CategoryProducts
                .FirstOrDefaultAsync(cp => cp.ProductId == pProductId && cp.CategoryId == pCategoryId);

            if (categoryProduct != null)
            {
                // Kaydı sil ve kaydedilen satır sayısını kontrol et
                context.CategoryProducts.Remove(categoryProduct);
                int affectedRows = await context.SaveChangesAsync();

                // Eğer en az bir satır silindi ise true döndür
                return affectedRows > 0;
            }

            // Eğer kayıt bulunamazsa veya silinemezse false döndür
            return false;
        }
        catch (Exception ex)
        {
            // Hata durumunda false döndür
            return false;
        }
    }
}

