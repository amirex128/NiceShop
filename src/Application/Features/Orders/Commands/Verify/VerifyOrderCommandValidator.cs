using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Orders.Commands.Verify;

public class VerifyOrderCommandValidator : AbstractValidator<VerifyOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public VerifyOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;


    }
}
