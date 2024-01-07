using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class ReturnRepository(ApplicationDbContext context, ILogger<Repository<Return>> logger)
    : Repository<Return>(context, logger), IReturnRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Return>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Returns.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
