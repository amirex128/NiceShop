using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class WishlistRepository(ApplicationDbContext context, ILogger<Repository<Wishlist>> logger)
    : Repository<Wishlist>(context, logger), IWishlistRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pagination<Wishlist>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Wishlists.AsQueryable();
        
        return await queryable.PaginatedListAsync(pageNumber, pageSize);
    }
}
