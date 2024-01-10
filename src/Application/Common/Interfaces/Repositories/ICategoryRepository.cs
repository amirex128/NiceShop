using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    public Task<Pagination<Category>> GetWithPaginationAsync(int pageNumber, int pageSize);
    public Task<Category?> GetByIdWithMediasAsync(int id);
    
}
