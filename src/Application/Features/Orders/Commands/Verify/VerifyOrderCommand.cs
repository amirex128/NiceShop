using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Orders.Commands.Verify;

public record VerifyOrderCommand : IRequest<Result>
{
    public int OrderId { get; set; }
    public string? Token { get; set; }
}
