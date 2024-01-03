using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Queries.GetWithPagination;

public class GetArticlesWithPaginationQueryHandler(IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<GetArticlesWithPaginationQuery, PaginatedList<ArticleDto>>
{

    public async Task<PaginatedList<ArticleDto>> Handle(GetArticlesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.ArticleRepository.AsQueryable();

        var paginatedList =
            await PaginatedList<Article>.CreateAsync(queryable, request.PageNumber, request.PageSize);

        return mapper.Map<PaginatedList<ArticleDto>>(paginatedList);
        
    }
}
