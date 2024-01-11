namespace NiceShop.Domain.Entities;

public class Basket : BaseAuditableEntity
{
    public long RawQuantityPrice { get; set; }
    public long TotalCouponPrice { get; set; }
    public long FinalPrice { get; set; }

    public int? CouponId { get; set; }
    public Coupon? Coupon { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();
}
