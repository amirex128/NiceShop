using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context, ILogger<Repository<Product>> logger)
    : Repository<Product>(context, logger), IProductRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Product>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Products.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
