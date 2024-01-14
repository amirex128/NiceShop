using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Create;

public record CreateProductReviewCommand : IRequest<Result>
{
    public int? Rating { get; set; }
    public string ReviewText { get; set; } = "";
    public int ProductId { get; set; }
}
