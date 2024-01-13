using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductReviews.Commands.Create;

public class CreateProductReviewCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateProductReviewCommand, Result>
{
    public async Task<Result> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductReview
        {
            Rating = request.Rating ?? 0, ReviewText = request.ReviewText, ProductId = request.ProductId
        };
        
        await context.ProductReviews.AddAsync(entity, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
