namespace NiceShop.Domain.Entities;

public class ProductReview : BaseAuditableEntity
{
    public int Rating { get; set; }
    public int Like { get; set; }
    public int Dislike { get; set; }
    public required string ReviewText { get; set; }
    public int ProductId { get; set; }
}
