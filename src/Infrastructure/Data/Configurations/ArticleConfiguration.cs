using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Medias).WithOne();
        builder.HasMany(p=>p.Categories).WithMany();

    }
}
