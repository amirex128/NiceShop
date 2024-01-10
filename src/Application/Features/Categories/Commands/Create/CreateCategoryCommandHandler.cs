using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateCategoryCommand, Result>
{
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            ParentCategoryId = request.ParentCategoryId,
            Description = request.Description,
            SeoTags = request.SeoTags,
        };
        
        if (request.Medias is not null && request.Medias.Any())
        {
            category.Medias = await context.Medias.Where(c => request.Medias.Contains(c.Id)).ToListAsync();
        }

        await context.Categories.AddAsync(category);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
