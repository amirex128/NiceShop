namespace NiceShop.Domain.Entities;

public class Coupon : BaseAuditableEntity
{
    public string Code { get; set; } = "";
    public int Quantity { get; set; }
    public CouponTypeEnum Type { get; set; }
    public long Value { get; set; }
    public DateTime ExpiryDate { get; set; }
    public List<Product> Products { get; set; } = new();
    public List<User> UsedBy { get; set; } = new();
}
