using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Addresses.Queries.GetById;

public record GetAddressByIdQuery(int Id) : IRequest<AddressDto>;

public class GetAddressByIdHandler : IRequestHandler<GetAddressByIdQuery, AddressDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAddressByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AddressDto> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Addresses.Where(x => x.Id == request.Id)
            .ProjectTo<AddressDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        
        Guard.Against.NotFound(request.Id, result);
        
        return result;
    }
}
