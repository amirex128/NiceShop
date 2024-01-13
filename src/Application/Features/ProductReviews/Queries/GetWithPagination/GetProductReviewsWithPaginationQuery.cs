using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Queries.GetWithPagination;

public record GetProductReviewsWithPaginationQuery : IRequest<Pagination<ProductReviewDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public required int ProductId { get; init; }
}
