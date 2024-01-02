using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public class CouponDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Coupon, CouponDto>();
        }
    }
}
