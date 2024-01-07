using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Queries.GetWithPagination;

public class CouponDto
{
    public int Id { get; init; }
    public required string Code { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpiryDate { get; set; }
    public CouponTypeEnum Type { get; set; }
    public int Value { get; set; }
    public List<Product>? Products { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Pagination<Coupon>, Pagination<CouponDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
            
        }
    }
}
