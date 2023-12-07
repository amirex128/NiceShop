using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public record UpdateCategoryCommand : IRequest<Dictionary<string, object>>
{
    public int Id { get; init; }
}

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
    }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Dictionary<string, object>>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new Dictionary<string, object>();
    }
}
