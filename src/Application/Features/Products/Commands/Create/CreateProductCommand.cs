using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Products.Commands.Create;

public record CreateProductCommand : IRequest<Result>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required long Price { get; set; }
    public required int Stock { get; set; }
    public required StatusEnum Status { get; set; }
    public int[]? Categories { get; set; }
    public int[]? ProductVariants { get; set; }
    public int[]? Medias { get; set; }
    public int[]? ProductAttributes { get; set; }
    public int[]? ProductReviews { get; set; }
}
