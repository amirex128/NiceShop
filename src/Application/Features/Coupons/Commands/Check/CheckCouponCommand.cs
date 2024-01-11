using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Check;

public record CheckCouponCommand : IRequest<Result>
{
    public required string Code { get; set; }
    public required int BasketId { get; set; }
    
}
