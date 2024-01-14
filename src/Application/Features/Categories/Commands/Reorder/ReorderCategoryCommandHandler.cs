using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Reorder;

public class ReorderCategoryCommandHandler(IApplicationDbContext context)
    : IRequestHandler<ReorderCategoryCommand, Result>
{
    public async Task<Result> Handle(ReorderCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, category);

        var allCategories =
            await context.Categories
                .Where(x => x.ParentCategoryId == category.ParentCategoryId)
                .OrderBy(x => x.Order)
                .ToListAsync(cancellationToken: cancellationToken);

        int oldOrder = category.Order;
        category.Order = request.Order;

        if (oldOrder < request.Order)
        {
            foreach (Category allCategory in allCategories)
            {
                if (allCategory.Order > oldOrder && allCategory.Order <= request.Order && allCategory.Id != category.Id)
                {
                    allCategory.Order--;
                }
            }
        }
        else if (oldOrder > request.Order)
        {
            foreach (Category allCategory in allCategories)
            {
                if (allCategory.Order < oldOrder && allCategory.Order >= request.Order && allCategory.Id != category.Id)
                {
                    allCategory.Order++;
                }
            }
        }

        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.OperationSuccess() : Result.OperationFailed();
    }
}
