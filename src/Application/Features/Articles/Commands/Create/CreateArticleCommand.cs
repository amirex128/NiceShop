using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public record CreateArticleCommand : IRequest<Result>
{
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public string Body { get; set; } = "";
    public string Slug { get; set; } = "";
    public string[]? SeoTags { get; set; }
    public int[]? Medias { get; set; }
    public int[]? Categories { get; set; }
}
