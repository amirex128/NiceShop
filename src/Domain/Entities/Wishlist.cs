namespace NiceShop.Domain.Entities;

public class Wishlist : BaseAuditableEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
