using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Baskets.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Baskets.Queries.GetById;

public class GetBasketByIdHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetBasketByIdQuery, BasketDto>
{
    public async Task<BasketDto> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Baskets
            .Include(x => x.BasketItems)
            .SingleOrDefaultAsync(x => x.Id == request.Id);

        Guard.Against.NotFound(request.Id, result);
        return mapper.Map<BasketDto>(result);
    }
}
