namespace NiceShop.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public long TotalQuantityPrice { get; set; }
    public long TotalCouponPrice { get; set; }
    public long TotalPrice { get; set; }
    
    public long TotalTaxPrice { get; set; }
    public long TotalSendPrice { get; set; }
    
    public string? Description { get; set; }
    public string? PackageSize { get; set; }
    public int Weight { get; set; }
    
    public string? TrackingCode { get; set; }
    public CourierEnum Courier { get; set; }
    public DateTime LastStatusUpdatedAt { get; set; }
    public string? Ip { get; set; }

    public int BasketId { get; set; }
    public Basket? Basket { get; set; }
    public OrderStatusEnum OrderStatus { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public List<OrderItem> OrderItems { get; set; } = null!;
}
