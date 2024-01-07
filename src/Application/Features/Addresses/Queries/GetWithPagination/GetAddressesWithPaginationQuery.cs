using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination
{
    public record GetAddressesWithPaginationQuery : IRequest<Pagination<AddressDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
