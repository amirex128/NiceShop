using NiceShop.Application.Common.Models;
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
    public List<Category>? Categories { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Article, ArticleDto>().ReverseMap();
            CreateMap<PaginatedList<Category>, PaginatedList<ArticleDto>>()
                .ConvertUsing((source, destination, context) =>
                    new PaginatedList<ArticleDto>
                    {
                        PageNumber = source.PageNumber,
                        TotalPages = source.TotalPages,
                        TotalCount = source.TotalCount,
                        Items = source.Items?.Select(item => context.Mapper.Map<ArticleDto>(item)).ToList()
                    });
        }
    }
}
