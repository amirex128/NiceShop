namespace NiceShop.Domain.Entities;

public class ProductVariant : BaseAuditableEntity
{
    public int ProductId  { get; set; }
    public string Name  { get; set; } = null!;
    public long Price  { get; set; }
    public int Stock  { get; set; }
}
