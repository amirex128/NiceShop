using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.BasketId)
            .NotEmpty().WithMessage("BasketId is required")
            .Must(basketId => _context.Baskets.Any(x => x.Id == basketId))
            .WithMessage("Basket not found");
    }
}
