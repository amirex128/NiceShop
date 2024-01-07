using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IOrderRepository: IRepository<Order>
{
    public Task<Pagination<Order>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
