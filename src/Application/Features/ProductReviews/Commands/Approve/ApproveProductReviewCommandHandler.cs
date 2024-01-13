using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductReviews.Commands.Approve;

public class ApproveProductReviewCommandHandler(IApplicationDbContext context)
    : IRequestHandler<ApproveProductReviewCommand, Result>
{
    public async Task<Result> Handle(ApproveProductReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductReviews.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);
        entity.Approved = !entity.Approved;
        
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.OperationSuccess() : Result.OperationFailed();
    }
}
