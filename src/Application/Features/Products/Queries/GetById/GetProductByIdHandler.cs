using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Products.Queries.GetById;

public class GetProductByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Products
            .FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<ProductDto>(result);
    }
}
