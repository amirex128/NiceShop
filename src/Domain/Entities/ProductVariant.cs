namespace NiceShop.Domain.Entities;

public class ProductVariant : BaseAuditableEntity
{
    public int ProductId  { get; set; }
    public required string Name  { get; set; }
    public long Price  { get; set; }
    public int Stock  { get; set; }
}
