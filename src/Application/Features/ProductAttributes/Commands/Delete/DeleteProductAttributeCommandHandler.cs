using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Delete;

public class DeleteProductAttributeCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductAttributeCommand, Result>
{
    public async Task<Result> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
    {
        var article = await context.ProductAttributes.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        context.ProductAttributes.Remove(article);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
