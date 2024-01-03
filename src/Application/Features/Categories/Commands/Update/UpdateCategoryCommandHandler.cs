using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, Result>
{
    public async Task<Result> Handle(UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CategoryRepository
            .GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.SeoTags = request.SeoTags ?? entity.SeoTags;

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

        var result = unitOfWork.CategoryRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
