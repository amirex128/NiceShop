using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface ICouponRepository: IRepository<Coupon>
{
    public Task<Pagination<Coupon>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
