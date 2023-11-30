using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p=>p.Coupon).WithMany().HasForeignKey(p=>p.CouponId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(p=>p.User).WithMany().HasForeignKey(p=>p.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
