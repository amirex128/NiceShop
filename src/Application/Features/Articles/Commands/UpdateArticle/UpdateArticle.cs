using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Articles.Commands.UpdateArticle;

public record UpdateArticleCommand : IRequest<bool>
{
    public int Id { get; init; }
}

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
    {
    }
}

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Articles
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
        
    }
}
