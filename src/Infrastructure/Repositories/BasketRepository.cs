using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class BasketRepository(ApplicationDbContext context, ILogger<Repository<Basket>> logger)
    : Repository<Basket>(context, logger), IBasketRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Basket>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Baskets.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
