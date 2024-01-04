using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Create;

public record CreateCouponCommand : IRequest<Result>
{
    public required string Code { get; set; }
    public required int Quantity { get; set; }
    public required DateTime ExpiryDate { get; set; }
    public required CouponTypeEnum Type { get; set; }
    public required int Value { get; set; }
    public int[]? Products { get; set; }
}
