using NiceShop.Application.Common.Interfaces;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Addresses.Commands.CreateAddress;

public record CreateAddressCommand : IRequest<int>
{
    public string? Title { get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public int CityId { get; set; }
    public int ProvinceId { get; set; }
    public string? UserId { get; set; }
}

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
    }
}

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAddressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        Address entity = new Address();

        _context.Addresses.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
