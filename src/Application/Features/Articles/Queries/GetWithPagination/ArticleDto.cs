using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Categories.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Queries.GetWithPagination;

public class ArticleDto
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
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<Pagination<Article>, Pagination<ArticleDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
        }
    }
}
