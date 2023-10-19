using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Domain.Entities.Common;

namespace RetailAdminHub.Domain.Entities;

public class Account : BaseEntity
{
    public int AccountNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime LastActivityDate { get; set; }
    public int PasswordRetryCount { get; set; }
}

public class AccountConfigruration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateUserId).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.AccountNumber).IsRequired(true);
        builder.HasIndex(x => x.AccountNumber).IsUnique(true);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Role).IsRequired().HasMaxLength(10);
        builder.Property(x => x.LastActivityDate).IsRequired();
        builder.Property(x => x.PasswordRetryCount).IsRequired().HasDefaultValue(0);

        builder.HasIndex(x => x.AccountNumber).IsUnique(true);
        builder.HasIndex(x => x.Email).IsUnique(true);
    }
}

