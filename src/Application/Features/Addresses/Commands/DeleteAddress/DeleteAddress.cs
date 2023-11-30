using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Addresses.Commands.DeleteAddress;

public record DeleteAddressCommand(int Id) : IRequest<bool>;


public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
{
    public DeleteAddressCommandValidator()
    {
    }
}

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Addresses
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Addresses.Remove(entity);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
