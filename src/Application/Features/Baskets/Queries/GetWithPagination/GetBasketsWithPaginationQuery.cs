using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Baskets.Queries.GetWithPagination;

public record GetBasketsWithPaginationQuery : IRequest<Pagination<BasketDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
