using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductVariants.Commands.Delete;

public class DeleteProductVariantCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductVariantCommand, Result>
{
    public async Task<Result> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
    {
        var result = await context.ProductVariants.Where(b => b.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
