using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCouponCommand, Result>
{
    public async Task<Result> Handle(DeleteCouponCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CouponRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, category);
        var result = unitOfWork.CouponRepository.Delete(category);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Deleted() : Result.FailedDelete();
    }
}
