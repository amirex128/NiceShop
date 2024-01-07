using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IReturnRepository: IRepository<Return>
{
    public Task<Pagination<Return>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
