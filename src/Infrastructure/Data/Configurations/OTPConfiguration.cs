using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class OTPConfiguration : IEntityTypeConfiguration<OTP>
{
    public void Configure(EntityTypeBuilder<OTP> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.User).WithOne().HasForeignKey<OTP>(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
