using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Create;

public record CreateProductReviewCommand : IRequest<Result>
{
    public int? Rating { get; set; }
    public required string ReviewText { get; set; }
    public required int ProductId { get; set; }
}
