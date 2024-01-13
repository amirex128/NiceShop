using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Products.Commands.Update;

public record UpdateProductCommand : IRequest<Result>
{
    public required int Id { get; init; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public long? Price { get; set; }
    public int? Stock { get; set; }
    public int? DiscountPercent { get; set; }
    public int? Weight { get; set; }
    public bool? FreeSend { get; set; }
    public bool? HasGuarantee { get; set; }
    public string? LongDescription { get; set; }
    public string? Barcode { get; set; }
    public string? Slug { get; set; }
    public string[]? SeoTags { get; set; }
    public StatusEnum? Status { get; set; }
    public int[]? Categories { get; set; }
    public int[]? ProductVariants { get; set; }
    public int[]? Medias { get; set; }
    public int[]? ProductAttributes { get; set; }
}
