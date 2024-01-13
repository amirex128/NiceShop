using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Create;

public record CreateProductAttributeCommand : IRequest<Result>
{
    public required int ProductId { get; set; }
    public required ProductAttributeTypeEnum Type { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
}
