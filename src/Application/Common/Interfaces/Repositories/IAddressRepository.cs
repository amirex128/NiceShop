using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IAddressRepository: IRepository<Address>
{
    public Task<Pagination<Address>> GetWithPaginationAsync(int pageNumber, int pageSize);
}
