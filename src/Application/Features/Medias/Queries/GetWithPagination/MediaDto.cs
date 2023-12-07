using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination;

public class MediaDto
{
    public int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Media, MediaDto>();
        }
    }
}
