using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class AddressRepository(ApplicationDbContext context, ILogger<Repository<Address>> logger)
    : Repository<Address>(context, logger), IAddressRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pagination<Address>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.Addresses.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
    }
}
