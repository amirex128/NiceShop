using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateAddressCommand, Result>
{
    public async Task<Result> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        await context.Addresses.AddAsync(new Address
        {
            Title = request.Title,
            AddressLine = request.AddressLine,
            PostalCode = request.PostalCode,
            CityId = request.CityId,
            ProvinceId = request.ProvinceId
        });

        var result = await context.SaveChangesAsync(cancellationToken);
        
        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
