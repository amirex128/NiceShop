using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Check;

public record CheckCouponCommand : IRequest<Result>
{
    public string Code { get; set; } = "";
    public int BasketId { get; set; }
}
