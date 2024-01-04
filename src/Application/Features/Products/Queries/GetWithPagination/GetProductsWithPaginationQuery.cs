using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Products.Queries.GetWithPagination;

public record GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
