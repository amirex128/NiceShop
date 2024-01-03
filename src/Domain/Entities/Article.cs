namespace NiceShop.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Body { get; set; }
    public required string Slug { get; set; }
    public List<Media>? Medias { get; set; }
    public List<Category>? Categories { get; set; }
}
