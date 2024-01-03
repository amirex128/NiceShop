using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateArticleCommand, Result>
{
    public async Task<Result> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ArticleRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title ?? entity.Title;
        entity.Description = request.Description ?? entity.Description;
        entity.Body = request.Body ?? entity.Body;
        entity.Slug = request.Slug ?? entity.Slug;

        if (request.Medias != null)
        {
            if (entity.Medias == null || entity.Medias.Count == 0)
            {
                entity.Medias = request.Medias.Select(v => new Media { Id = v }).ToList();
            }
            else
            {
                var currentMediaIds = entity.Medias.Select(m => m.Id).ToList();
                var mediaIdsToAdd = request.Medias.Except(currentMediaIds!).ToList();
                var mediaIdsToRemove = currentMediaIds.Except(request.Medias).ToList();

                entity.Medias.AddRange(mediaIdsToAdd.Select(id => new Media { Id = id }));

                var mediasToRemove = entity.Medias.Where(m => mediaIdsToRemove.Contains(m.Id)).ToList();
                entity.Medias = entity.Medias.Except(mediasToRemove).ToList();
            }
        }

        if (request.Categories != null)
        {
            if (entity.Categories == null || entity.Categories.Count == 0)
            {
                entity.Categories = request.Categories.Select(v => new Category { Id = v }).ToList();
            }
            else
            {
                var currentCategoryIds = entity.Categories.Select(m => m.Id).ToList();
                var categoryIdsToAdd = request.Categories.Except(currentCategoryIds!).ToList();
                var categoryIdsToRemove = currentCategoryIds.Except(request.Categories).ToList();

                entity.Categories.AddRange(categoryIdsToAdd.Select(id => new Category { Id = id }));

                var mediasToRemove = entity.Categories.Where(m => categoryIdsToRemove.Contains(m.Id)).ToList();
                entity.Categories = entity.Categories.Except(mediasToRemove).ToList();
            }
        }

        var result = unitOfWork.ArticleRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
