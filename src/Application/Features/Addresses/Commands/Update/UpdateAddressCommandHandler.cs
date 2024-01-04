using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateAddressCommand, Result>
{

    public async Task<Result> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.AddressRepository
            .GetByIdAsync(request.Id);
        
        Guard.Against.NotFound(request.Id, entity);
        entity.Title = request.Title ?? entity.Title;
        entity.AddressLine = request.AddressLine ?? entity.AddressLine;
        entity.PostalCode = request.PostalCode ?? entity.PostalCode;
        entity.CityId = request.CityId ?? entity.CityId;
        entity.ProvinceId = request.ProvinceId ?? entity.ProvinceId;
        
        var result = unitOfWork.AddressRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
