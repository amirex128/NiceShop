using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public class CategoryDto
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public int? ParentCategoryId { get; set; }

    public string? Description { get; set; }
    
    public string[]? SeoTags { get; set; }

    public List<Media>? Medias { get; set; }
    public List<Category>? SubCategories { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<PaginatedList<Category>, PaginatedList<CategoryDto>>()
                .ConvertUsing((source, destination, context) =>
                    new PaginatedList<CategoryDto>
                    {
                        PageNumber = source.PageNumber,
                        TotalPages = source.TotalPages,
                        TotalCount = source.TotalCount,
                        Items = source.Items?.Select(item => context.Mapper.Map<CategoryDto>(item)).ToList()
                    });
        }
    }
}
