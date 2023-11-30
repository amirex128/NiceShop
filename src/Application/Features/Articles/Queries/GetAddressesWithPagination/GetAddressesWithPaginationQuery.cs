using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Queries.GetArticlesWithPagination;

public record GetArticlesWithPaginationQuery : IRequest<PaginatedList<ArticleDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetArticlesWithPaginationQueryHandler : IRequestHandler<GetArticlesWithPaginationQuery, PaginatedList<ArticleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArticlesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ArticleDto>> Handle(GetArticlesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult<PaginatedList<ArticleDto>>(null!);
    }
}
