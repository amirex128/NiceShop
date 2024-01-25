using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Delete;

public class DeleteProductAttributeCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteProductAttributeCommand, Result>
{
    public async Task<Result> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
    {
        var result = await context.ProductAttributes.Where(b => b.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
