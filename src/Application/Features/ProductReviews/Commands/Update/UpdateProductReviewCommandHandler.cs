using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductReviews.Commands.Update;

public class UpdateProductReviewCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateProductReviewCommand, Result>
{
    public async Task<Result> Handle(UpdateProductReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.ProductReviews.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Rating = request.Rating ?? entity.Rating;
        entity.ReviewText = request.ReviewText ?? entity.ReviewText;
        
        context.ProductReviews.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
