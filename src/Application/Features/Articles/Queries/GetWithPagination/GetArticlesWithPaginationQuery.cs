using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Queries.GetWithPagination;

public record GetArticlesWithPaginationQuery : IRequest<Pagination<ArticleDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
