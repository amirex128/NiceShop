using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class SubscriptionRepository(ApplicationDbContext context, ILogger<Repository<Subscription>> logger)
    : Repository<Subscription>(context, logger), ISubscriptionRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pagination<Subscription>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Subscriptions.AsQueryable();
        
        return await queryable.PaginatedListAsync(pageNumber, pageSize);
    }
}
