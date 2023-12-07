using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Medias.Commands.Delete;

public record DeleteMediaCommand(int Id) : IRequest<Dictionary<string, object>>;


public class DeleteMediaCommandValidator : AbstractValidator<DeleteMediaCommand>
{
    public DeleteMediaCommandValidator()
    {
    }
}

public class DeleteMediaCommandHandler : IRequestHandler<DeleteMediaCommand, Dictionary<string, object>>
{
    private readonly IApplicationDbContext _context;

    public DeleteMediaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, object>> Handle(DeleteMediaCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Medias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Medias.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return new Dictionary<string, object>();
    }
}
