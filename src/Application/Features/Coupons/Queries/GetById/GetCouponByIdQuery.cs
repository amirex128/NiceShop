using NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Coupons.Queries.GetById;

public record GetCouponByIdQuery(int Id) : IRequest<CouponDto>;
