using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class MediaRepository(ApplicationDbContext context, ILogger<Repository<Media>> logger)
    : Repository<Media>(context, logger), IMediaRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<Media>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Medias.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
