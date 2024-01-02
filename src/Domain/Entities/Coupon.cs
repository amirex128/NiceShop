namespace NiceShop.Domain.Entities;

public class Coupon : BaseAuditableEntity
{
    public required string Code { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
    public required string UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Product> Products { get; set; } = null!;
}

public class CouponFixedAmount : Coupon
{
    public long FixedAmount { get; set; }
}

public class CouponPercentage : Coupon
{
    public int Percentage { get; set; }
}
