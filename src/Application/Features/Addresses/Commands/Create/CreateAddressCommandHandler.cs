using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateAddressCommand, Result>
{
    
    public async Task<Result> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.AddressRepository.AddAsync(new Address
        {
            Title = request.Title,
            AddressLine = request.AddressLine,
            PostalCode = request.PostalCode,
            CityId = request.CityId,
            ProvinceId = request.ProvinceId
        });
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result? Result.Created() : Result.FailedCreate();
    }
}
