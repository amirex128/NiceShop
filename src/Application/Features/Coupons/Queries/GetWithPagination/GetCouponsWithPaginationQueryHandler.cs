using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public class GetCouponsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCouponsWithPaginationQuery, PaginatedList<CouponDto>>
{
    public async Task<PaginatedList<CouponDto>> Handle(GetCouponsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.CouponRepository.AsQueryable();

        var paginatedList =
            await PaginatedList<Coupon>.CreateAsync(queryable, request.PageNumber, request.PageSize);

        return mapper.Map<PaginatedList<CouponDto>>(paginatedList);
        
    }
}
