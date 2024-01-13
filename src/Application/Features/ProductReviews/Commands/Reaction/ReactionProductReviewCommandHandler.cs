using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductReviews.Commands.Reaction;

public class CreateProductReviewCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateProductReviewCommand, Result>
{
    public async Task<Result> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductReviews.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);
        if (request.ReactionPositive)
        {
            entity.Like++;
        }
        else
        {
            entity.Dislike++;
        }

        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.OperationSuccess() : Result.OperationFailed();
    }
}
