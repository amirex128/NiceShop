using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Delete;

public class DeleteMediaCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteMediaCommand, Result>
{
    public async Task<Result> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Medias
            .FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        context.Medias.Remove(entity);
        
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
