namespace NiceShop.Domain.Entities;

public class Coupon : BaseAuditableEntity
{
    public string Code { get; set; }= "";
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
    public List<Product> Products { get; set; } = null!;
}

public class CouponFixedAmount : Coupon
{
    public long FixedAmount { get; set; }
}

public class CouponPercentage : Coupon
{
    public int Percentage { get; set; }
}
