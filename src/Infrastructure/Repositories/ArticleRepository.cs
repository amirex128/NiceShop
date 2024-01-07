using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;
using NiceShop.Infrastructure.Services;

namespace NiceShop.Infrastructure.Repositories;

public class ArticleRepository : Repository<Article>, IArticleRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<Repository<Article>> _logger;

    public ArticleRepository(ApplicationDbContext context, ILogger<Repository<Article>> logger)
        : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Article?> GetByIdWithCategoriesAndMediasAsync(int id)
    {
        return await _context.Articles
            .Where(x => x.Id == id)
            .Include(x => x.Categories)
            .Include(x => x.Medias)
            .Select(x => new Article
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Body = x.Body,
                Slug = x.Slug,
                Categories =
                    x.Categories.Select(c => new Category { Id = c.Id, Name = c.Name, Slug = c.Slug }).ToList(),
                Medias = x.Medias.ToList()
            })
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<Pagination<Article>> GetWithPagination(int pageNumber, int pageSize)
    {
        var queryable = _context.Articles
            .Include(x => x.Categories)
            .Include(x => x.Medias)
            .Select(x => new Article
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Body = x.Body,
                Slug = x.Slug,
                Categories =
                    x.Categories.Select(c => new Category { Id = c.Id, Name = c.Name, Slug = c.Slug }).ToList(),
                Medias = x.Medias.ToList()
            })
            .AsNoTracking()
            .AsQueryable();

        return await queryable.PaginatedListAsync(pageNumber, pageSize);
    }
}
