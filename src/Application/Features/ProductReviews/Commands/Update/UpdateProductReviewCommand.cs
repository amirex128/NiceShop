using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Update;

public record UpdateProductReviewCommand : IRequest<Result>
{
    public required long Id { get; set; }
    public int? Rating { get; set; }
    public string? ReviewText { get; set; }
}
