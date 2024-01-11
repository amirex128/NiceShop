using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Baskets.Commands.Create;

public record CreateBasketCommand : IRequest<Result>
{
    public required List<BasketItemDto> BasketItems { get; set; }
}
