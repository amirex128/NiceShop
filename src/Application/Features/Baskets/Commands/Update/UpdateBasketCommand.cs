using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;

namespace NiceShop.Application.Features.Baskets.Commands.Update;

public record UpdateBasketCommand : IRequest<Result>
{
    public int Id { get; init; }
    public List<BasketItemDto> BasketItems { get; init; } = new();
}
