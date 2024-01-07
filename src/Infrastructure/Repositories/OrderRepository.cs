using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context, ILogger<Repository<Order>> logger)
    : Repository<Order>(context, logger), IOrderRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Order>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Orders.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
