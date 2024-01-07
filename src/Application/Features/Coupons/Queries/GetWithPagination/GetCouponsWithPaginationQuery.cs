using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public record GetCouponsWithPaginationQuery : IRequest<Pagination<CouponDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
