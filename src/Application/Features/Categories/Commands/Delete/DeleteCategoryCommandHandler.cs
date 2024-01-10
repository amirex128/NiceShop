using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteCategoryCommand, Result>
{
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, category);
        context.Categories.Remove(category);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
