using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Queries.GetWithPagination;

public class GetProductReviewsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductReviewsWithPaginationQuery, Pagination<ProductReviewDto>>
{
    public async Task<Pagination<ProductReviewDto>> Handle(GetProductReviewsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedList = await context.ProductReviews
            .Where(x => x.ProductId == request.ProductId)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<ProductReviewDto>>(paginatedList);
    }
}
