using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination
{
    public record GetAddressesWithPaginationQuery : IRequest<PaginatedList<AddressDto>>
    {
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}
