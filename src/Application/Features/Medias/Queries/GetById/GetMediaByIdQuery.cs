using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Medias.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Medias.Queries.GetById;

public record GetMediaByIdQuery(int Id) : IRequest<MediaDto?>;

public class GetMediaByIdHandler : IRequestHandler<GetMediaByIdQuery, MediaDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetMediaByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MediaDto?> Handle(GetMediaByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Medias.Where(x => x.Id == request.Id)
            .ProjectTo<MediaDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
    }
}
