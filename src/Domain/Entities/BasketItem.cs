namespace NiceShop.Domain.Entities;

public class BasketItem : BaseAuditableEntity
{
    public int Quantity { get; set; }
    public long Price { get; set; }
    public long QuantityPrice { get; set; }
    public int BasketId { get; set; }
    public Basket? Basket { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; } 
    public int? ProductVariantId { get; set; }
    public ProductVariant? ProductVariant { get; set; }
}
