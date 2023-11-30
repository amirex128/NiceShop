namespace NiceShop.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name  { get; set; } = null!;
    public int? ParentCategoryId  { get; set; }
    public ICollection<Category> SubCategories  { get; set; } = null!;
    public ICollection<Product> Products  { get; set; } = null!;
    public ICollection<Article> Articles  { get; set; } = null!;
}
