using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductVariants.Commands.Create;

public class CreateProductVariantCommandValidator : AbstractValidator<CreateProductVariantCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductVariantCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.ProductId)
            .NotEmpty().WithMessage("ProductId is required")
            .GreaterThan(0).WithMessage("ProductId must be greater than 0")
            .MustAsync(async (productId, cancellationToken) =>
                await context.Products.AnyAsync(p => p.Id == productId, cancellationToken))
            .WithMessage("Product does not exist");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(v => v.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(v => v.Stock)
            .NotEmpty().WithMessage("Stock is required")
            .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to 0");
    }
}
