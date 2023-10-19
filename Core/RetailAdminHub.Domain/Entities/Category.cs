using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities.Common;

namespace RetailAdminHub.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    //Many-to-many
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        // Primary key
        builder.HasKey(c => c.Id);

        // Name property
        builder.Property(c => c.Name)
            .IsRequired() // Name is required
            .HasMaxLength(250); // Max length of 250

        // Description property
        builder.Property(c => c.Description)
            .HasMaxLength(500); // Max length of 500

        // Index on Name
        builder.HasIndex(c => c.Name).IsUnique();

        // Many-to-many relationship with Product
        builder.HasMany(c => c.Products)
            .WithMany(p => p.Categories); // Assuming Product entity has ICollection<Category> Categories

        // ... Any other configuration for Category
    }
}