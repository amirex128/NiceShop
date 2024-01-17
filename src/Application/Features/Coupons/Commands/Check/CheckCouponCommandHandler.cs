using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Check;

public class CheckCouponCommandHandler(IApplicationDbContext context, IUser user)
    : IRequestHandler<CheckCouponCommand, Result>
{
    public async Task<Result> Handle(CheckCouponCommand request, CancellationToken cancellationToken)
    {
        Basket? basket = await context.Baskets.Include(x => x.BasketItems)
            .SingleOrDefaultAsync(x => x.Id == request.BasketId, cancellationToken);

        if (basket is null)
            return Result.OperationFailed("سبد خرید یافت نشد.");

        if (basket.CouponId is not null)
            return Result.OperationFailed("کد تخفیف قبلا اعمال شده");

        Coupon? coupon = await context.Coupon
            .Include(x => x.UsedBy)
            .Where(x => x.Code == request.Code && x.Quantity > 0 && x.ExpiryDate > DateTime.Now)
            .SingleOrDefaultAsync(cancellationToken);

        if (coupon is null)
            return Result.OperationFailed("کد تخفیف یافت نشد.");


        foreach (User usedUser in coupon.UsedBy)
        {
            if (usedUser.Id == user.Id)
            {
                return Result.OperationFailed("این کد تخفیف قبلا استفاده شده است.");
            }
        }

        if (coupon.Type == CouponTypeEnum.Percentage)
            basket.TotalCouponPrice = basket.TotalQuantityPrice * coupon.Value / 100;
        else
            basket.TotalCouponPrice = coupon.Value;

        basket.TotalPrice = basket.TotalQuantityPrice - basket.TotalCouponPrice;
        basket.CouponId = coupon.Id;
        coupon.Quantity--;
        coupon.UsedBy.Add((await context.Users.FindAsync(user.Id))!);


        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result.OperationSuccess("کد تخفبف روی سبد خرید شما اعمال شد.").WithObject(basket)
            : Result.OperationFailed("خطا در ثبت اطلاعات.");
    }
}
