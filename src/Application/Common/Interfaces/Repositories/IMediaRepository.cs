using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IMediaRepository: IRepository<Media>
{
    public Task<Pagination<Media>> GetWithPaginationAsync(int pageNumber, int pageSize);

}
