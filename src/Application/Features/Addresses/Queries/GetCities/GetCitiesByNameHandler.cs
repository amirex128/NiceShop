using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;


namespace NiceShop.Application.Features.Addresses.Queries.GetCities;

public class GetCitiesByNameHandler(IApplicationDbContext context) : IRequestHandler<GetCitiesByNameQuery, List<City>>
{

    public async Task<List<City>> Handle(GetCitiesByNameQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Cities
            .Where(x => request.Name == null || x.Name.Contains(request.Name))
            .Where(x=> request.ProvinceId == null || x.ProvinceId == request.ProvinceId)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}
