using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceShop.Domain.Enums;

namespace NiceShop.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(p => p.Orders).WithOne(p => p.User).HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Wishlists).WithOne().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(p => p.IsActive).HasConversion(new EnumToStringConverter<StatusEnum>());

        // builder.OwnsOne(p => p.Social);
    }
}
