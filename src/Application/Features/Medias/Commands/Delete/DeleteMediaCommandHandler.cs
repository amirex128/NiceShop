using Microsoft.AspNetCore.Hosting;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Medias.Commands.Delete;

public class DeleteMediaCommandHandler(IApplicationDbContext context,IWebHostEnvironment hostingEnvironment)
    : IRequestHandler<DeleteMediaCommand, Result>
{
    public async Task<Result> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Medias
            .FindAsync(request.Id);

        Guard.Against.NotFound(request.Id, entity);

        string? entityRelativePath = entity.RelativePath;
        if (entityRelativePath is not null)
        {
            string entityFullPath = Path.Combine(hostingEnvironment.WebRootPath, "media", entityRelativePath);
            if (File.Exists(entityFullPath))
            {
                File.Delete(entityFullPath);
            }
        }

        context.Medias.Remove(entity);
        
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Deleted() : Result.FailedDelete();
    }
}
