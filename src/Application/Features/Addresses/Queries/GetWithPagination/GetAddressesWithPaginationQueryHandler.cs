using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

public class GetAddressesWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAddressesWithPaginationQuery, PaginatedList<AddressDto>>
{
    public async Task<PaginatedList<AddressDto>> Handle(GetAddressesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var queryable = unitOfWork.AddressRepository.AsQueryable();

        var paginatedList =
            await PaginatedList<Address>.CreateAsync(queryable, request.PageNumber, request.PageSize);

        return mapper.Map<PaginatedList<AddressDto>>(paginatedList);
    }
}
