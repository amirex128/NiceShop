namespace NiceShop.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long Price { get; set; }
    public int TotalSales { get; set; }
    public int Stock { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    
    public List<Category> Categories { get; set; } = null!;
    public List<ProductVariant> ProductVariants { get; set; } = null!;
    public List<Coupon> Coupons { get; set; } = null!;
    public List<Media> Medias { get; set; } = null!;
    public List<ProductAttribute> ProductAttributes { get; set; } = null!;
    public List<ProductReview> ProductReviews { get; set; } = null!;


}
