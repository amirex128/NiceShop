using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.ProductVariants.Commands.Create;

public record CreateProductVariantCommand : IRequest<Result>
{
    public required int ProductId  { get; set; }
    public required string Name  { get; set; }
    public required long Price  { get; set; }
    public required int Stock  { get; set; }
}
