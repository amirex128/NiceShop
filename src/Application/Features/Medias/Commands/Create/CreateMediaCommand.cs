using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Commands.Create;

public record CreateMediaCommand : IRequest<int>
{
    public required IFormFile File { get; init; }
    public string? Alt { get; set; }
}

public class CreateMediaCommandValidator : AbstractValidator<CreateMediaCommand>
{
    public CreateMediaCommandValidator()
    {
        RuleFor(v => v.Alt).MaximumLength(1000);
    }
}

public class CreateMediaCommandHandler(IApplicationDbContext context, IWebHostEnvironment hostingEnvironment,
        IUser user)
    : IRequestHandler<CreateMediaCommand, int>
{
    public async Task<int> Handle(CreateMediaCommand request, CancellationToken cancellationToken)
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
            UserId = user.Id,
            FileName = fileName,
            FullPath = fullPath,
            Extension = fileExtension,
            Size = infoLength,
            RelativePath = relativePath,
            Alt = request.Alt
        };

        context.Medias.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
