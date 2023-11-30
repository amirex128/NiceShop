
namespace NiceShop.Domain.Entities;

public class Return : BaseAuditableEntity
{
    public string ReturnReason  { get; set; } = null!;
    public OrderStatusEnum OrderStatus  { get; set; }
    public int OrderId  { get; set; }
    public Order Order  { get; set; } = null!;
    public int OrderItemId  { get; set; }
    public OrderItem OrderItem  { get; set; } = null!;
    public required string UserId  { get; set; }    public User User  { get; set; } = null!;
    public int ProductId  { get; set; }
    public Product Product  { get; set; } = null!;
}
