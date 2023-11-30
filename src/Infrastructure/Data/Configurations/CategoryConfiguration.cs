using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NiceShop.Infrastructure.Data.Configurations;

public class CategoryConfiguration  : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasMany(p => p.Articles).WithMany(p => p.Categories);
        builder.HasMany(p=>p.Products).WithMany(p=>p.Categories);
        builder.HasMany(p => p.SubCategories).WithOne().HasForeignKey(p => p.ParentCategoryId).OnDelete(DeleteBehavior.NoAction);
    }
} 
