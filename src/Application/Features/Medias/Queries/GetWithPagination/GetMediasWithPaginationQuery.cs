using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination
{
    public record GetMediasWithPaginationQuery : IRequest<Pagination<MediaDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
