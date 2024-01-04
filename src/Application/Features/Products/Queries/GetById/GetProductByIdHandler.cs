using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Products.Queries.GetWithPagination;

namespace NiceShop.Application.Features.Products.Queries.GetById;

public class GetProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<ProductDto>(result);
    }
}
