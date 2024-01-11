using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Baskets.Queries.GetWithPagination;

public class GetBasketsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetBasketsWithPaginationQuery, Pagination<BasketDto>>
{
    public async Task<Pagination<BasketDto>> Handle(GetBasketsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await context.Baskets.Include(x=>x.BasketItems).PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<BasketDto>>(paginatedList);
    }
}
