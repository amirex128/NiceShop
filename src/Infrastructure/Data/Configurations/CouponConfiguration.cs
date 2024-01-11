using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceShop.Domain.Enums;

namespace NiceShop.Infrastructure.Data.Configurations;

public class CouponConfiguration  : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p=>p.Products).WithMany(p=>p.Coupons);
        builder.HasMany(p=>p.UsedBy).WithMany();
        builder.Property(p=>p.Type).HasConversion(new EnumToStringConverter<CouponTypeEnum>());

    }
}
