using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities.Common;
using System.Collections.Generic;

namespace RetailAdminHub.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; }
    public float Price { get; set; }
    // Many-to-many 
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        // Primary key
        builder.HasKey(p => p.Id);

        // Name property
        builder.Property(p => p.Name)
            .IsRequired() // Name is required
            .HasMaxLength(250); // Max length of 250

        // Stock property
        builder.Property(p => p.Stock)
            .IsRequired(); // Stock is required

        // Price property
        builder.Property(p => p.Price)
            .IsRequired() // Price is required
            .HasColumnType("float");

        // Index on Name
        builder.HasIndex(p => p.Name).IsUnique();

        // Many-to-many relationship with Category
        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products); // Assuming Category entity has ICollection<Product> Products

        // ... Any other configuration for Product
    }
}