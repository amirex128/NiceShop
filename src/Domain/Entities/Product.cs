namespace NiceShop.Domain.Entities;

public class Product : BaseAuditableEntity
{

    public string Name  { get; set; } = null!;
    public string Description  { get; set; } = null!;
    public long Price  { get; set; }
    public int TotalSales  { get; set; }
    public int Stock  { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public ICollection<Category> Categories  { get; set; } = null!;
    public ICollection<ProductVariant> ProductVariants  { get; set; } = null!;
    public ICollection<Coupon> Coupons  { get; set; } = null!;
    public ICollection<Media> Medias  { get; set; } = null!;
    public ICollection<ProductAttribute> ProductAttributes  { get; set; } = null!;
    public ICollection<ProductReview> ProductReviews  { get; set; } = null!;
}
