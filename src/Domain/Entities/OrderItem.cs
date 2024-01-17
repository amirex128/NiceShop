namespace NiceShop.Domain.Entities;

public class OrderItem : BaseAuditableEntity
{
    public int Quantity { get; set; }
    public long Price { get; set; }
    public long QuantityPrice { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    public int? ProductVariantId { get; set; }
    public ProductVariant? ProductVariant { get; set; }
}
