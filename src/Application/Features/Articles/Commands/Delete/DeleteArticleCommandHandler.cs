using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Delete;

public class DeleteArticleCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteArticleCommand, Result>
{
    public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await unitOfWork.ArticleRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        var result = unitOfWork.ArticleRepository.Delete(article);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Deleted() : Result.FailedDelete();
    }
}
