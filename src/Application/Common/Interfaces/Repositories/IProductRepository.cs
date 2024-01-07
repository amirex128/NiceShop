using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IProductRepository: IRepository<Product>
{
    public Task<Pagination<Product>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
