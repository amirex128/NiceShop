using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Coupons.Queries.GetById;

public record GetCouponByIdQuery(int Id) : IRequest<CouponDto>;

public class GetCouponByIdHandler : IRequestHandler<GetCouponByIdQuery, CouponDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCouponByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CouponDto> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.CouponPercentage.Where(x => x.Id == request.Id)
            .ProjectTo<CouponDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        
        Guard.Against.NotFound(request.Id, result);
        
        return result;
    }
}
