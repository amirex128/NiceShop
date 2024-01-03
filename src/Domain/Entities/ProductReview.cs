
namespace NiceShop.Domain.Entities;

public class ProductReview  : BaseAuditableEntity
{
    public int Rating  { get; set; }
    public string ReviewText  { get; set; } = null!;
    public int ProductId  { get; set; }
    
}
