namespace NiceShop.Domain.Entities;

public class Order : BaseAuditableEntity
{
    public long TotalProductPrice { get; set; }
    public long TotalDiscountPrice { get; set; }
    public long TotalTaxPrice { get; set; }
    public long TotalSendPrice { get; set; }
    public long TotalFinalPrice { get; set; }
    public string? Description { get; set; }
    public string? PackageSize { get; set; }
    public string? TrackingCode { get; set; }
    public CourierEnum Courier { get; set; }
    public DateTime LastStatusUpdatedAt { get; set; }
    public int Weight { get; set; }
    public string? Ip { get; set; }

    public OrderStatusEnum OrderStatus { get; set; }
    public int? AddressId { get; set; }
    public Address? Address { get; set; }
    public required string UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<OrderItem> OrderItems { get; set; } = null!;
}
