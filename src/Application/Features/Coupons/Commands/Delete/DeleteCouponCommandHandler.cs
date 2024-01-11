using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCouponCommand, Result>
{
    public async Task<Result> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var result = await context.Coupon.Where(b => b.Id < 3).ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
