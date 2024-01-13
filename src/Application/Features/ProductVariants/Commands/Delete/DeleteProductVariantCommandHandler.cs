using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductVariants.Commands.Delete;

public class DeleteProductVariantCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductVariantCommand, Result>
{
    public async Task<Result> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
    {
        var article = await context.ProductVariants.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        context.ProductVariants.Remove(article);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
