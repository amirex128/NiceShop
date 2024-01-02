using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Products.Queries.GetById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Products.Where(x => x.Id == request.Id)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
        
        Guard.Against.NotFound(request.Id, result);
        
        return result;
    }
}
