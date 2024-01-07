using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IProvinceRepository: IRepository<Province>
{
    public Task<Pagination<Province>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
