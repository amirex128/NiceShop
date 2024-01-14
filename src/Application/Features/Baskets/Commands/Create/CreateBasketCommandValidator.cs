using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandValidator : AbstractValidator<CreateBasketCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateBasketCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.BasketItems)
            .NotEmpty().WithMessage("BasketItems is required.")
            .Must(AllProductsExist).WithMessage("One or more products do not exist.");

        RuleForEach(v => v.BasketItems)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId)
                    .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            });
    }

    private bool AllProductsExist(List<BasketItemDto> basketItems)
    {
        var productIds = basketItems.Select(i => i.ProductId);
        var existingProductIds = _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Select(p => p.Id)
            .ToList();

        return productIds.All(id => existingProductIds.Contains(id));
    }
}
