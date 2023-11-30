namespace NiceShop.Domain.Entities;

public class ProductAttribute : BaseAuditableEntity
{

    public int ProductId  { get; set; }
    public string Name  { get; set; } = null!;
    public string Value  { get; set; } = null!;
}
