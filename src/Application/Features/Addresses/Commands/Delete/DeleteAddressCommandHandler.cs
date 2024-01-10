using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Addresses.Commands.Delete;

public class DeleteAddressCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteAddressCommand, Result>
{
    public async Task<Result> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var address = await context.Addresses.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, address);
        context.Addresses.Remove(address);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
