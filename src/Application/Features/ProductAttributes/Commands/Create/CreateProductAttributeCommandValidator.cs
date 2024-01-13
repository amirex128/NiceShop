using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Create;

public class CreateProductAttributeCommandValidator : AbstractValidator<CreateProductAttributeCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductAttributeCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.")
            .MustAsync(async (productId, cancellationToken) =>
                await _context.Products.AnyAsync(p => p.Id == productId, cancellationToken))
            .WithMessage("Product with the given id does not exist.");

        RuleFor(v => v.Type)
            .IsInEnum().WithMessage("Type must be a valid ProductAttributeTypeEnum.");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.Value)
            .NotEmpty().WithMessage("Value is required.")
            .MaximumLength(500).WithMessage("Value must not exceed 500 characters.");
    }
}
