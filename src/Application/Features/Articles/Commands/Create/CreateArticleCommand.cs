using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public record CreateArticleCommand : IRequest<Result>
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Body { get; set; }
    public required string Slug { get; set; }
    public string[]? SeoTags { get; set; }
    public int[]? Medias { get; set; }
    public int[]? Categories { get; set; }
}
