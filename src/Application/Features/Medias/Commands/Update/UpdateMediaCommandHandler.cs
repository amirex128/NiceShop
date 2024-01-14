using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Update;

public class UpdateMediaCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateMediaCommand, Result>
{
    public async Task<Result> Handle(UpdateMediaCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await context.Medias
            .FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        entity.Alt = request.Alt ?? entity.Alt;
        
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
