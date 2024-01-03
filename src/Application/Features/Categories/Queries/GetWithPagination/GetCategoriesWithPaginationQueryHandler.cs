using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public class
    GetCategoriesWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoriesWithPaginationQuery,
        PaginatedList<CategoryDto>>
{
    public async Task<PaginatedList<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.CategoryRepository.AsQueryable();

        var paginatedList =
            await PaginatedList<Category>.CreateAsync(queryable, request.PageNumber, request.PageSize);

        return mapper.Map<PaginatedList<CategoryDto>>(paginatedList);
    }
}
