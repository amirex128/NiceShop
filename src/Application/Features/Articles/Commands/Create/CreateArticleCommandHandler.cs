using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public class CreateArticleCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateArticleCommand, Result>
{
    public async Task<Result> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var article = new Article
        {
            Title = request.Title, Description = request.Description, Body = request.Body, Slug = request.Slug
        };

        if (request.Categories is not null && request.Categories.Any())
        {
            var categories = await context.Categories.Where(c => request.Categories.Contains(c.Id)).ToListAsync();
            article.Categories = categories;
        }

        if (request.Medias is not null && request.Medias.Any())
        {
            var medias = await context.Medias.Where(c => request.Medias.Contains(c.Id)).ToListAsync();
            article.Medias = medias;
        }

        await context.Articles.AddAsync(article);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
