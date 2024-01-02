using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NiceShop.Domain.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long NationalCode { get; set; }
    public StatusEnum IsActive { get; set; }
    public bool IsAdmin { get; set; }

    public Social Social { get; set; } = new Social();
    public ICollection<Media> Medias { get; set; } = null!;
    public ICollection<Wishlist> Wishlists { get; set; } = null!;
    public ICollection<Address> Addresses { get; set; } = null!;
    public ICollection<Article> Articles { get; set; } = null!;
    public ICollection<Coupon> Coupons { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = null!;
    public ICollection<ProductReview> ProductReviews { get; set; } = null!;
    public ICollection<Return> Returns { get; set; } = null!;
}

public class Social
{
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }
}
