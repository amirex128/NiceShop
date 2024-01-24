using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public class
    GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCategoriesWithPaginationQuery,
        Pagination<CategoryDto>>
{
    public async Task<Pagination<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await context.Categories
            .Include(x=>x.Medias)
            
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<CategoryDto>>(paginatedList);
    }
}
