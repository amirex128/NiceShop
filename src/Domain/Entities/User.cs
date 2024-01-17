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
    
    public DateTimeOffset LastModified { get; set; }
    public DateTimeOffset Created { get; set; }
    public string? LastModifiedBy { get; set; }

    public Otp? Otp { get; set; }
    public Social Social { get; set; } = new Social();
    public List<Media> Medias { get; set; } = null!;
    public List<Product> Wishlists { get; set; } = null!;
    public List<Address> Addresses { get; set; } = null!;
    public List<Article> Articles { get; set; } = null!;
    public List<Coupon> Coupons { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
    public List<Order> Orders { get; set; } = null!;
    public List<ProductReview> ProductReviews { get; set; } = null!;
    public List<Return> Returns { get; set; } = null!;
    
    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public class Social
{
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }
    public string? Twitter { get; set; }
}
