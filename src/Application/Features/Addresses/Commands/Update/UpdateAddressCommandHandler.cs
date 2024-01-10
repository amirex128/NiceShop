using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateAddressCommand, Result>
{
    public async Task<Result> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Addresses.FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title ?? entity.Title;
        entity.AddressLine = request.AddressLine ?? entity.AddressLine;
        entity.PostalCode = request.PostalCode ?? entity.PostalCode;
        entity.CityId = request.CityId ?? entity.CityId;
        entity.ProvinceId = request.ProvinceId ?? entity.ProvinceId;

        context.Addresses.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
