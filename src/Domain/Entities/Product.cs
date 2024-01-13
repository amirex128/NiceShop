namespace NiceShop.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public long Price { get; set; }

    public int TotalSales { get; set; }
    public int Stock { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public int DiscountPercent { get; set; }
    public int Weight { get; set; }
    public bool FreeSend { get; set; }
    public bool HasGuarantee { get; set; }
    public string? LongDescription { get; set; }
    public string? Barcode { get; set; }
    public required string Slug { get; set; }
    
    private string? _seoTags;
    public string[]? SeoTags
    {
        get => _seoTags?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        set => _seoTags = string.Join(",", value ?? Array.Empty<string>());
    }

    public List<Category>? Categories { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }
    public List<Coupon>? Coupons { get; set; }
    public List<Media>? Medias { get; set; }
    public List<ProductAttribute>? ProductAttributes { get; set; }
    public List<ProductReview>? ProductReviews { get; set; }
}
