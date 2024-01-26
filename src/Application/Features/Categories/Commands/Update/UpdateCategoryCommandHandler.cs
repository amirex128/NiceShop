using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateCategoryCommand, Result>
{
    public async Task<Result> Handle(UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Categories
            .Include(x => x.Medias)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.SeoTags = request.SeoTags ?? entity.SeoTags;
        entity.Slug = request.Slug ?? entity.Slug;

        if (request.Medias is not null && request.Medias.Any())
        {
            entity.Medias?.Clear();
            entity.Medias = await context.Medias.Where(c => request.Medias.Contains(c.Id))
                .ToListAsync(cancellationToken: cancellationToken);
        }

        context.Categories.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
