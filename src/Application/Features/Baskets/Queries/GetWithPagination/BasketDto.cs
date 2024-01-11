using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Baskets.Queries.GetWithPagination;

public class BasketDto
{
    public int Id { get; init; }
    public long RawQuantityPrice  { get; set; }
    public long TotalCouponPrice  { get; set; }
    public long FinalPrice  { get; set; }
    public List<BasketItem> BasketItems { get; set; } = new();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<Pagination<Basket>, Pagination<BasketDto>>()
                .ForMember(dest =>
                    dest.Items, opt =>
                    opt.MapFrom(src => src.Items));
        }
    }
}
