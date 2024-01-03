using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public class CreateArticleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleCommand, Result>
{
    public async Task<Result> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.ArticleRepository.AddAsync(new Article
        {
            Title = request.Title,
            Description = request.Description,
            Body = request.Body,
            Slug = request.Slug,
            Medias = request.Medias?.Select(x => new Media { Id = x }).ToList(),
            Categories = request.Categories?.Select(x => new Category { Id = x }).ToList()
        });
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result? Result.Created() : Result.FailedCreate();
    }
}
