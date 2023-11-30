using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasOne(p => p.Media).WithMany().HasForeignKey(p=> p.MediaId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(p => p.User).WithMany(p => p.Articles).HasForeignKey(p => p.UserId);
    }
}
