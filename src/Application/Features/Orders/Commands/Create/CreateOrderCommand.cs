using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Orders.Commands.Create;

public record CreateOrderCommand : IRequest<Result>
{
    public int BasketId { get; set; }
    public int AddressId { get; set; }
    public string? Description { get; set; }
}
