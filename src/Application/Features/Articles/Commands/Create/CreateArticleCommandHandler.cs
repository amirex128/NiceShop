using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public class CreateArticleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleCommand, Result>
{
    public async Task<Result> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var categories = request.Categories != null 
            ? await unitOfWork.CategoryRepository.GetByIdsAsync(request.Categories) 
            : null;
        var medias = request.Medias != null 
            ? await unitOfWork.MediaRepository.GetByIdsAsync(request.Medias) 
            : null;
        
        var result = await unitOfWork.ArticleRepository.AddAsync(new Article
        {
            Title = request.Title,
            Description = request.Description,
            Body = request.Body,
            Slug = request.Slug,
            Medias = medias!,
            Categories = categories!
        });
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result? Result.Created() : Result.FailedCreate();
    }
}
