using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Medias.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Medias.Queries.GetById;

public class GetMediaByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetMediaByIdQuery, MediaDto?>
{
    public async Task<MediaDto?> Handle(GetMediaByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Medias.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<MediaDto>(result);
    }
}
