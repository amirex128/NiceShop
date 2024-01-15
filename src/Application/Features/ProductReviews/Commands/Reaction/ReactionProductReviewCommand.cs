using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Reaction;

public record ReactionProductReviewCommand : IRequest<Result>
{
    public long Id { get; set; }
    public bool ReactionPositive { get; set; }
}
