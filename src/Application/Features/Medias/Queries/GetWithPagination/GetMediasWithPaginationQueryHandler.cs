using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination;

public class GetMediasWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetMediasWithPaginationQuery, Pagination<MediaDto>>
{
    public async Task<Pagination<MediaDto>> Handle(GetMediasWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await context.Medias.PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<MediaDto>>(paginatedList);
        
    }
}
