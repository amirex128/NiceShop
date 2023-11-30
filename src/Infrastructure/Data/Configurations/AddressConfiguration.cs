using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.City).WithMany().HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(p => p.Province).WithMany().HasForeignKey(p=> p.ProvinceId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(p => p.User).WithMany(p => p.Addresses).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
