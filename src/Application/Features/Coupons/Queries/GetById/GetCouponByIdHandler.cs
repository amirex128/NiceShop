using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Coupons.Queries.GetById;

public class GetCouponByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCouponByIdQuery, CouponDto>
{
    public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.CouponRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<CouponDto>(result);
    }
}
