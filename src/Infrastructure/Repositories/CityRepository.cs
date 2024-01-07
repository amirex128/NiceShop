using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class CityRepository(ApplicationDbContext context, ILogger<Repository<City>> logger)
    : Repository<City>(context, logger), ICityRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<City>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Cities.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
