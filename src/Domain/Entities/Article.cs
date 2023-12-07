namespace NiceShop.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Body { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public int Sort { get; set; }
    public required string UserId { get; set; }
    public User? User { get; set; }
    public int? MediaId { get; set; }
    public Media? Media { get; set; }
    public ICollection<Category>? Categories { get; set; }
}
