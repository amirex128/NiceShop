using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Addresses.Commands.Update;

public record UpdateAddressCommand : IRequest<bool>
{
    public int Id { get; init; }
}

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
    }
}

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Addresses
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
