using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Create;

public record CreateProductAttributeCommand : IRequest<Result>
{
    public int ProductId { get; set; }
    public ProductAttributeTypeEnum Type { get; set; }
    public string Name { get; set; } = "";
    public string Value { get; set; } = "";
}
