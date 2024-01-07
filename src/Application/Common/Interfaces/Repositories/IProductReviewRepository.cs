using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IProductReviewRepository: IRepository<ProductReview>
{
    public Task<Pagination<ProductReview>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
