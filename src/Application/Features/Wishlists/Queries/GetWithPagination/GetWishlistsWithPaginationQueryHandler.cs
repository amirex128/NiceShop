using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Wishlists.Queries.GetWithPagination;

public class GetWishlistsWithPaginationQueryHandler(
    IApplicationDbContext context,
    IUser userId,
    IMapper mapper)
    : IRequestHandler<GetWishlistsWithPaginationQuery, Pagination<ProductDto>>
{
    public async Task<Pagination<ProductDto>> Handle(GetWishlistsWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var userWithWishlists = await context.Users
            .Include(u => u.Wishlists)
            .FirstOrDefaultAsync(u => u.Id == userId.Id, cancellationToken: cancellationToken);

        var queryable = context.Products
            .Where(x => userWithWishlists!.Wishlists.Contains(x))
            .AsQueryable();
        
        var paginatedList = await queryable.PaginatedListAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<ProductDto>>(paginatedList);
    }
}
