using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Wishlists.Queries.GetWithPagination;

public record GetWishlistsWithPaginationQuery : IRequest<Pagination<ProductDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
