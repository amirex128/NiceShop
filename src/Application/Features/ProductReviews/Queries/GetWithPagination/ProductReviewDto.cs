using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductReviews.Queries.GetWithPagination;

public class ProductReviewDto
{
    public int Id { get; init; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Body { get; set; }
    public required string Slug { get; set; }
    public List<Media>? Medias { get; set; }
    public List<CategoryDto>? Categories { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
            CreateMap<Pagination<ProductReview>, Pagination<ProductReviewDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
        }
    }
}
