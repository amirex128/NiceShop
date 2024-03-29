using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Coupons.Queries.GetById;

public class GetCouponByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCouponByIdQuery, CouponDto>
{
    public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Coupon
            .Include(x => x.Products)
            .SingleOrDefaultAsync(x => x.Id == request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<CouponDto>(result);
    }
}
