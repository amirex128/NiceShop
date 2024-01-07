namespace NiceShop.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public string Body { get; set; } = "";
    public string Slug { get; set; } = "";
    public List<Media> Medias { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
}
