using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context, ILogger<Repository<Category>> logger)
    : Repository<Category>(context, logger), ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Category>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Categories.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
