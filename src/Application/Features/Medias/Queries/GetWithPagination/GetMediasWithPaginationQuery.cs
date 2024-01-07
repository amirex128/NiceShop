using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Queries.GetWithPagination
{
    public record GetMediasWithPaginationQuery : IRequest<Pagination<MediaDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetMediasWithPaginationQueryHandler : IRequestHandler<GetMediasWithPaginationQuery, Pagination<MediaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMediasWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Pagination<MediaDto>> Handle(GetMediasWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult<Pagination<MediaDto>>(null!);
        }
    }
}
