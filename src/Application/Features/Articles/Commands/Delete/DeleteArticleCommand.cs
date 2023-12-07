using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Articles.Commands.Delete;

public record DeleteArticleCommand(int Id) : IRequest<bool>;

public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleCommandValidator()
    {
    }
}

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Articles
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Articles.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
        
    }
}
