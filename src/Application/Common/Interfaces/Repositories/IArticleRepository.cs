using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IArticleRepository : IRepository<Article>
{
    public Task<Article?> GetByIdWithCategoriesAndMediasAsync(int id);
    public Task<Article?> GetByIdWithCategoriesAndMediasAsNoTrackingAsync(int id);
    public Task<Pagination<Article>> GetWithPaginationAsync(int pageNumber, int pageSize);
}
