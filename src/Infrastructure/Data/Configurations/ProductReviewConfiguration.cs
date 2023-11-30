using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.User).WithMany(p=>p.ProductReviews).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
