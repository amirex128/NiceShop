using System.Linq.Expressions;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Update;

public record UpdateArticleCommand : IRequest<Result>
{
    public required int Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Body { get; init; }
    public string? Slug { get; init; }
    public int[]? Medias { get; init; }
    public int[]? Categories { get; init; }
}
