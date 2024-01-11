using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;

namespace NiceShop.Application.Features.Baskets.Commands.Update;

public record UpdateBasketCommand : IRequest<Result>
{
    public required int Id { get; init; }
    public required List<BasketItemDto> BasketItems { get; init; }
}
