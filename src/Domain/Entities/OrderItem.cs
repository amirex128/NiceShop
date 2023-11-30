namespace NiceShop.Domain.Entities;

public class OrderItem : BaseAuditableEntity
{
    public int Count  { get; set; }
    public long RawPrice  { get; set; }
    public long RawPriceVariant  { get; set; }
    public long PriceWithCount  { get; set; }
    public long DiscountPrice  { get; set; }
    public long FinalPrice  { get; set; }
    
    public int OrderId  { get; set; }
    public Order Order  { get; set; } = null!;
    public int? ProductId  { get; set; }
    public Product? Product  { get; set; }
    public int? ProductVariantId  { get; set; }
    public ProductVariant? ProductVariant  { get; set; }
}
