﻿using NiceShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceShop.Domain.Enums;

namespace NiceShop.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(x => x.Otp)
            .WithOne(x => x.User)
            .HasForeignKey<Otp>(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(p => p.Orders)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(p => p.Medias)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(p => p.IsActive)
            .HasConversion(new EnumToStringConverter<StatusEnum>());
        
        builder.HasMany(p => p.Articles)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(p => p.Coupons)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(u => u.Products)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(x => x.Wishlists)
            .WithMany();
        
        builder.OwnsOne(p => p.Social);
    }
}
