using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface ICityRepository: IRepository<City>
{
    public Task<Pagination<City>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
