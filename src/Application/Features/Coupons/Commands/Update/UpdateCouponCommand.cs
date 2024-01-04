using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Update;

public record UpdateCouponCommand : IRequest<Result>
{
    public required int Id { get; init; }
    public string? Code { get; set; }
    public int? Quantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public CouponTypeEnum? Type { get; set; }
    public int? Value { get; set; }
    public int[]? Products { get; set; }
}
