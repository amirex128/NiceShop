using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public record UpdateCategoryCommand : IRequest<Result>
{
    public int Id { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public string[]? SeoTags { get; set; }
    public int[]? Medias { get; init; }

}
