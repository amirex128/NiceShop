using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Features.Baskets.Commands.Create;

namespace NiceShop.Application.Features.Baskets.Commands.Update;

public class UpdateBasketCommandValidator : AbstractValidator<UpdateBasketCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBasketCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.")
            .Must( (id) =>
                 _context.Baskets.Any(b => b.Id == id))
            .WithMessage("Basket with the given id does not exist.");

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
