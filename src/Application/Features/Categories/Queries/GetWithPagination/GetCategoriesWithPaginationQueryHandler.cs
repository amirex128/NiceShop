using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Queries.GetWithPagination;

public class
    GetCategoriesWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoriesWithPaginationQuery,
        Pagination<CategoryDto>>
{
    public async Task<Pagination<CategoryDto>> Handle(GetCategoriesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await unitOfWork.CategoryRepository.GetWithPaginationAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<CategoryDto>>(paginatedList);
    }
}
