namespace NiceShop.Domain.Entities;

public class ProductAttribute : BaseAuditableEntity
{
    public int ProductId { get; set; }
    public ProductAttributeTypeEnum Type { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
}
