using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand, Result>
{


    public async Task<Result> Handle(UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CategoryRepository
            .GetByIdAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        if (request.Name != null)
        {
            entity.Name = request.Name;
        }

        if (request.Description != null)
        {
            entity.Description = request.Description;
        }

        if (request.SeoTags != null)
        {
            entity.SeoTags = request.SeoTags;
        }
        
        var result = await unitOfWork.CategoryRepository.UpdateAsync(request.Id, entity);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
