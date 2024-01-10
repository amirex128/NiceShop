using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateArticleCommand, Result>
{
    public async Task<Result> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Articles.Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title ?? entity.Title;
        entity.Description = request.Description ?? entity.Description;
        entity.Body = request.Body ?? entity.Body;
        entity.Slug = request.Slug ?? entity.Slug;

        if (request.Categories is not null)
            entity.Categories = context.Categories.Where(x => request.Categories.Contains(x.Id)).ToList();
        if (request.Medias is not null)
            entity.Medias = context.Medias.Where(x => request.Medias.Contains(x.Id)).ToList();

        context.Articles.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
