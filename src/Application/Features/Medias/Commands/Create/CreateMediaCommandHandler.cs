using Microsoft.AspNetCore.Hosting;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Commands.Create;

public class CreateMediaCommandHandler(IApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
    : IRequestHandler<CreateMediaCommand, Result>
{
    public async Task<Result> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
    {
        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "media");
        var fileInfo = new FileInfo(request.File.FileName);
        string fileExtension = fileInfo.Extension;
        string fileName = Guid.NewGuid() + fileExtension;
        string relativePath = Path.Combine("media", Guid.NewGuid() + fileExtension);
        string fullPath = Path.Combine(filePath, fileName);

        await using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream, cancellationToken);
        }

        long infoLength = new FileInfo(fullPath).Length;

        var entity = new Media()
        {
            FileName = fileName,
            FullPath = fullPath,
            Extension = fileExtension,
            Size = infoLength,
            RelativePath = relativePath,
            Alt = request.Alt
        };

        await context.Medias.AddAsync(entity);

        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
