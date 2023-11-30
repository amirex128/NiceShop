using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p=>p.Product).WithMany().HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p=>p.Basket).WithMany(p=>p.BasketItems).HasForeignKey(p=>p.BasketId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p=>p.ProductVariant).WithMany().HasForeignKey(p=>p.ProductVariantId).OnDelete(DeleteBehavior.SetNull);
    }
}
