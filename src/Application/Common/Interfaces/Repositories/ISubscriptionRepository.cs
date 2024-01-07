using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface ISubscriptionRepository: IRepository<Subscription>
{
    public Task<Pagination<Subscription>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
