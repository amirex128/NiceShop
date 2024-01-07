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
            CreateMap<Pagination<Category>, Pagination<CategoryDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
        }
    }
}
