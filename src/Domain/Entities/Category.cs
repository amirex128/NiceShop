namespace NiceShop.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public required string Name { get; set; }
    public int? ParentCategoryId { get; set; }

    public string? Description { get; set; }

    private string? _seoTags;

    public string[]? SeoTags
    {
        get => _seoTags?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        set => _seoTags = string.Join(",", value ?? Array.Empty<string>());
    }

    public ICollection<Media>? Medias { get; set; }
    public ICollection<Category>? SubCategories { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Article>? Articles { get; set; }
}
