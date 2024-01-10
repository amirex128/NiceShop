using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public class GetCouponsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCouponsWithPaginationQuery, Pagination<CouponDto>>
{
    public async Task<Pagination<CouponDto>> Handle(GetCouponsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await context.Coupon.PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<CouponDto>>(paginatedList);
        
    }
}
