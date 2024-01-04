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

        var medias = entity.Medias?.ToList();

        unitOfWork.MediaRepository.UpdateEntityCollection(ref medias, request.Medias);

        entity.Medias = medias;
        
        var result = unitOfWork.CategoryRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
