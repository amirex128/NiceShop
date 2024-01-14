using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateCategoryCommand, Result>
{
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var lastOrder = await context.Categories.Where(x =>
                request.ParentCategoryId == null
                    ? x.ParentCategoryId == null
                    : x.ParentCategoryId == request.ParentCategoryId)
            .OrderByDescending(x => x.Order)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        var category = new Category
        {
            Name = request.Name,
            ParentCategoryId = request.ParentCategoryId,
            Description = request.Description,
            SeoTags = request.SeoTags,
            Slug = request.Slug,
            Order = lastOrder is null ? 1 : lastOrder.Order + 1
        };

        if (request.Medias is not null && request.Medias.Any())
        {
            category.Medias = await context.Medias.Where(c => request.Medias.Contains(c.Id)).ToListAsync();
        }

        await context.Categories.AddAsync(category, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
