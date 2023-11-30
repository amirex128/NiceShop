using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<Customer> Customers { get; }
    public DbSet<Address> Addresses { get; }
    public DbSet<Article> Articles { get; }
    public DbSet<Basket> Baskets { get; }
    public DbSet<BasketItem> BasketItems { get; }
    public DbSet<Category> Categories { get; }
    public DbSet<City> Cities { get; }
    public DbSet<Coupon> Coupons { get; }
    public DbSet<Media> Media { get; }
    public DbSet<Order> Orders { get; }
    public DbSet<OrderItem> OrderItems { get; }
    public DbSet<OTP> OTPs { get; }
    public DbSet<Product> Products { get; }
    public DbSet<ProductAttribute> ProductAttributes { get; }
    public DbSet<ProductVariant> ProductVariants { get; }
    public DbSet<ProductReview> ProductReviews { get; }
    public DbSet<Province> Provinces { get; }
    public DbSet<Return> Returns { get; }
    public DbSet<Subscription> Subscriptions { get; }
    public DbSet<Wishlist> Wishlists { get; }

    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
