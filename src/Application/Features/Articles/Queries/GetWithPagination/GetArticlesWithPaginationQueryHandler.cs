using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Queries.GetWithPagination;

public class GetArticlesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetArticlesWithPaginationQuery, Pagination<ArticleDto>>
{
    public async Task<Pagination<ArticleDto>> Handle(GetArticlesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await context.Articles.PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<ArticleDto>>(paginatedList);
    }
}
