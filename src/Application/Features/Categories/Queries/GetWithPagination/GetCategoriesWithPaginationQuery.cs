using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public record GetCategoriesWithPaginationQuery : IRequest<PaginatedList<CategoryDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
