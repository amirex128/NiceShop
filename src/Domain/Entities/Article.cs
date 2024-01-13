namespace NiceShop.Domain.Entities;

public class Article : BaseAuditableEntity
{
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public string Body { get; set; } = "";
    public string Slug { get; set; } = "";
    private string? _seoTags;

    public string[]? SeoTags
    {
        get => _seoTags?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        set => _seoTags = string.Join(",", value ?? Array.Empty<string>());
    }

    public List<Media> Medias { get; set; } = new();
    public List<Category> Categories { get; set; } = new();
}
