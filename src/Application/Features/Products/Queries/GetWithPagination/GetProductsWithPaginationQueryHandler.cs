using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Queries.GetWithPagination;

public class GetProductsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductDto>>
{

    public async Task<PaginatedList<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.ProductRepository.AsQueryable();

        var paginatedList =
            await PaginatedList<Product>.CreateAsync(queryable, request.PageNumber, request.PageSize);

        return mapper.Map<PaginatedList<ProductDto>>(paginatedList);
    }
}
