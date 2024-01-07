using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public class GetCouponsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCouponsWithPaginationQuery, Pagination<CouponDto>>
{
    public async Task<Pagination<CouponDto>> Handle(GetCouponsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await unitOfWork.CouponRepository.GetWithPaginationAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<CouponDto>>(paginatedList);
        
    }
}
