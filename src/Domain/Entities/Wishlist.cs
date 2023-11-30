namespace NiceShop.Domain.Entities;

public class Wishlist: BaseAuditableEntity
{

    public required string UserId  { get; set; }    public int ProductId  { get; set; }
    public Product Product  { get; set; } = null!;
}
