using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public record GetCouponsWithPaginationQuery : IRequest<PaginatedList<CouponDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
