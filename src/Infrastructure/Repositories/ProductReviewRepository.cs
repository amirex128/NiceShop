using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class ProductReviewRepository(ApplicationDbContext context, ILogger<Repository<ProductReview>> logger)
    : Repository<ProductReview>(context, logger), IProductReviewRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Pagination<ProductReview>> GetWithPaginationAsync(int pageNumber, int pageSize)
    {
        var queryable = _context.ProductReviews.AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
        
    }
}
