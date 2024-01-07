using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IBasketRepository: IRepository<Basket>
{
    public Task<Pagination<Basket>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
