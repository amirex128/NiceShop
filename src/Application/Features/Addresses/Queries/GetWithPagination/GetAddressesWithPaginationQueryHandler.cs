using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

public class GetAddressesWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAddressesWithPaginationQuery, Pagination<AddressDto>>
{
    public async Task<Pagination<AddressDto>> Handle(GetAddressesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var paginatedRes =
            await unitOfWork.AddressRepository.GetWithPaginationAsync(request.PageNumber, request.PageSize);
        return mapper.Map<Pagination<AddressDto>>(paginatedRes);
    }
}
