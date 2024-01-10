using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Queries.GetWithPagination;

public class GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductsWithPaginationQuery, Pagination<ProductDto>>
{

    public async Task<Pagination<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var paginatedList = await context.Products.PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<ProductDto>>(paginatedList);
    }
}
