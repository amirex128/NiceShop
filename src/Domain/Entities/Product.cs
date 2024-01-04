namespace NiceShop.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public long Price { get; set; }
    public int TotalSales { get; set; }
    public int Stock { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public List<Category>? Categories { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }
    public List<Coupon>? Coupons { get; set; }
    public List<Media>? Medias { get; set; }
    public List<ProductAttribute>? ProductAttributes { get; set; }
    public List<ProductReview>? ProductReviews { get; set; }
}
