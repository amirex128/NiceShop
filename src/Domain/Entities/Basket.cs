namespace NiceShop.Domain.Entities;

public class Basket : BaseAuditableEntity
{
    public long TotalQuantityPrice { get; set; }
    public long TotalCouponPrice { get; set; }
    public long TotalPrice { get; set; }
    public int? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();
}
