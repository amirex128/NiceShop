using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination
{
    public record GetMediasWithPaginationQuery : IRequest<PaginatedList<MediaDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetMediasWithPaginationQueryHandler : IRequestHandler<GetMediasWithPaginationQuery, PaginatedList<MediaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMediasWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<MediaDto>> Handle(GetMediasWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult<PaginatedList<MediaDto>>(null!);
        }
    }
}
