using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class ProvinceRepository(ApplicationDbContext context, ILogger<Repository<Province>> logger)
    : Repository<Province>(context, logger), IProvinceRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Province>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Provinces.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
