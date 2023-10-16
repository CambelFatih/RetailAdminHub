using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities.Common;
using System.Reflection.Emit;

namespace RetailAdminHub.Domain.Entities;

public class CategoryProduct
{
    public Guid ProductId { get; set; }
    public ICollection<Product> Product { get; set; }

    public Guid CategoryId { get; set; }
    public ICollection<Category> Category { get; set; }
}
public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
{
    public void Configure(EntityTypeBuilder<CategoryProduct> builder)
    {
        // Tablo adı ve anahtarlar
        builder.ToTable("CategoryProduct");
        builder.HasKey(cp => new { cp.CategoryId, cp.ProductId });


    }
}
