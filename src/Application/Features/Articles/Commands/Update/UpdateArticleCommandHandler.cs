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
        
        var medias = entity.Medias?.ToList();
        var categories = entity.Categories?.ToList();

        unitOfWork.MediaRepository.UpdateEntityCollection(ref medias, request.Medias);
        unitOfWork.CategoryRepository.UpdateEntityCollection(ref categories, request.Categories);

        entity.Categories = categories;
        entity.Medias = medias;
        
        var result = unitOfWork.ArticleRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
