using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCouponCommand, Result>
{
    public async Task<Result> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Coupon.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, category);
        context.Coupon.Remove(category);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
