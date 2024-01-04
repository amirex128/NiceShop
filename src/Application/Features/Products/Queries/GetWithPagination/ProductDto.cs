using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Products.Queries.GetWithPagination;

public class ProductDto
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public long Price { get; set; }
    public int TotalSales { get; set; }
    public int Stock { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public List<Category>? Categories { get; set; }
    public List<ProductVariant>? ProductVariants { get; set; }
    public List<Coupon>? Coupons { get; set; }
    public List<Media>? Medias { get; set; }
    public List<ProductAttribute>? ProductAttributes { get; set; }
    public List<ProductReview>? ProductReviews { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<PaginatedList<Product>, PaginatedList<ProductDto>>()
                .ConvertUsing((source, destination, context) =>
                    new PaginatedList<ProductDto>
                    {
                        PageNumber = source.PageNumber,
                        TotalPages = source.TotalPages,
                        TotalCount = source.TotalCount,
                        Items = source.Items?.Select(item => context.Mapper.Map<ProductDto>(item)).ToList()
                    });
        }
    }
}
