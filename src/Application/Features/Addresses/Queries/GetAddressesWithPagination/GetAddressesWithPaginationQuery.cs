using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Queries.GetAddressesWithPagination;

public record GetAddressesWithPaginationQuery : IRequest<PaginatedList<AddressDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetAddressesWithPaginationQueryHandler : IRequestHandler<GetAddressesWithPaginationQuery, PaginatedList<AddressDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<AddressDto>> Handle(GetAddressesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult<PaginatedList<AddressDto>>(null!);
    }
}
