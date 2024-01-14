using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public record CreateCategoryCommand : IRequest<Result>
{
    public string Name { get; set; } = "";
    public int? ParentCategoryId { get; set; }
    public string? Description { get; set; }
    public string[]? SeoTags { get; set; }
    public string Slug { get; set; } = "";
    public int[]? Medias { get; set; }
}
