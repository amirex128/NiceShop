using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IWishlistRepository: IRepository<Wishlist>
{
    public Task<Pagination<Wishlist>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
