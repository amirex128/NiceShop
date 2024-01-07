using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class CouponRepository(ApplicationDbContext context, ILogger<Repository<Coupon>> logger)
    : Repository<Coupon>(context, logger), ICouponRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Coupon>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Coupon.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
