using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteAddressCommand, Result>
{

    public async Task<Result> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await unitOfWork.AddressRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, address);
        var result = unitOfWork.AddressRepository.Delete(address);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Deleted() : Result.FailedDelete();
    }
}
