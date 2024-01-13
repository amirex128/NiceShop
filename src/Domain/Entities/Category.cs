namespace NiceShop.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; } = "";
    public int? ParentCategoryId { get; set; }

    public string? Description { get; set; }
    public required string Slug { get; set; }

    private string? _seoTags;

    public string[]? SeoTags
    {
        get => _seoTags?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        set => _seoTags = string.Join(",", value ?? Array.Empty<string>());
    }

    public List<Media>? Medias { get; set; }
    public List<Category>? SubCategories { get; set; }
    public List<Product>? Products { get; set; }
}
