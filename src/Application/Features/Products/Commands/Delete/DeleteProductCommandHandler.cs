using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Products.Commands.Delete;

public class DeleteProductCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var article = await context.Products.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        context.Products.Remove(article);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
