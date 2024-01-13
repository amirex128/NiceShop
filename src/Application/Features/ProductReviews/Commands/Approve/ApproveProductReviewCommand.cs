using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Approve;

public record ApproveProductReviewCommand : IRequest<Result>
{
    public long Id { get; set; }
}
