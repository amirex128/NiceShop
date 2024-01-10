using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Delete;

public class DeleteArticleCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteArticleCommand, Result>
{
    public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await context.Articles.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, article);
        context.Articles.Remove(article);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
