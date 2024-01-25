using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Delete;

public class DeleteProductReviewCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductReviewCommand, Result>
{
    public async Task<Result> Handle(DeleteProductReviewCommand request, CancellationToken cancellationToken)
    {
        var result = await context.ProductReviews.Where(b => b.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
