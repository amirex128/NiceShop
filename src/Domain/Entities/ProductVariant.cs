namespace NiceShop.Domain.Entities;

public class ProductVariant : BaseAuditableEntity
{
    public int ProductId  { get; set; }
    public string Name  { get; set; } = null!;
    public long PriceAdjustment  { get; set; }
    public int Stock  { get; set; }
}
