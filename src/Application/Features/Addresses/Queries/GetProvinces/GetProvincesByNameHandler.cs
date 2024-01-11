using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Addresses.Queries.GetWithPagination;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Queries.GetProvinces;

public class GetProvincesByNameHandler(IApplicationDbContext context) : IRequestHandler<GetProvincesByNameQuery, List<Province>>
{

    public async Task<List<Province>> Handle(GetProvincesByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Provinces
            .Where(x => request.Name == null || x.Name.Contains(request.Name))
            .ToListAsync(cancellationToken);
        
        return result;
    }
}
