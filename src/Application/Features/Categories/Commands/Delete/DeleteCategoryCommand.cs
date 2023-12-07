using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Categories.Commands.Delete;

public record DeleteCategoryCommand(int Id) : IRequest<Dictionary<string, object>>;


public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
    }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Dictionary<string, object>>
{
    private readonly IApplicationDbContext _context;

    public DeleteCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Categories.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new Dictionary<string, object>();
    }
}
