using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public record GetCouponsWithPaginationQuery : IRequest<PaginatedList<CouponDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetCouponsWithPaginationQueryHandler : IRequestHandler<GetCouponsWithPaginationQuery, PaginatedList<CouponDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCouponsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CouponDto>> Handle(GetCouponsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult<PaginatedList<CouponDto>>(null!);
    }
}
