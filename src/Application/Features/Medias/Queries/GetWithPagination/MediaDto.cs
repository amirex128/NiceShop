using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination;

public class MediaDto
{
    public int Id { get; init; }
    public string? FileName { get; set; }
    public string? FullPath { get; set; }
    public string? RelativePath { get; set; }
    public string? Alt { get; set; }
    public string? Extension { get; set; }
    public long Size { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Media, MediaDto>().ReverseMap();
            CreateMap<Pagination<Media>, Pagination<MediaDto>>()
                .ForMember(dest => 
                    dest.Items, opt => 
                    opt.MapFrom(src => src.Items));
            
        }
    }
}
