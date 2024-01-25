using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Articles.Commands.Delete;

public class DeleteArticleCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteArticleCommand, Result>
{
    public async Task<Result> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var result = await context.Articles.Where(b => b.Id == request.Id).ExecuteDeleteAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
