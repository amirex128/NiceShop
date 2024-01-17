using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceShop.Domain.Enums;

namespace NiceShop.Infrastructure.Data.Configurations;

public class OrderConfiguration  : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(x=>x.Basket).WithOne().HasForeignKey<Order>(x=>x.BasketId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p=>p.OrderItems).WithOne(p=>p.Order).HasForeignKey(p=>p.OrderId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p=>p.Coupon).WithMany().HasForeignKey(p=>p.CouponId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(p=>p.Address).WithMany().HasForeignKey(p=>p.AddressId).OnDelete(DeleteBehavior.NoAction);
        builder.Property(p=>p.OrderStatus).HasConversion(new EnumToStringConverter<OrderStatusEnum>());
    }
}
