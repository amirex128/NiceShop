using System.Reflection;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using NiceShop.Domain.Attributes;

namespace NiceShop.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Basket> Baskets => Set<Basket>();
    public DbSet<BasketItem> BasketItems => Set<BasketItem>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OTP> OTPs => Set<OTP>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<ProductReview> ProductReviews => Set<ProductReview>();
    public DbSet<Province> Provinces => Set<Province>();
    public DbSet<Return> Returns => Set<Return>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            if (entityType.ClrType.GetCustomAttributes(typeof(SoftDeleteAttribute), true).Length > 0)
            {
                builder.Entity(entityType.Name).Property<bool>("IsRemoved");
            }
        }

        base.OnModelCreating(builder);
    }

    public override int SaveChanges()
    {
        SetIsRemoved();

        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetIsRemoved();

        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        SetIsRemoved();

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        SetIsRemoved();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetIsRemoved()
    {
        var deletedState = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted);
        foreach (var entry in deletedState)
        {
            var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());
            var isRemoved = entityType?.FindProperty("IsRemoved");
            if (entry.State == EntityState.Deleted && isRemoved is not null)
            {
                entry.Property("IsRemoved").CurrentValue = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
