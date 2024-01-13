using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Coupons.Commands.Create;

public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
{
    public CreateCouponCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Code is required.")
            .MaximumLength(250).WithMessage("Code must not exceed 250 characters.");

        RuleFor(v => v.Quantity)
            .NotEmpty().WithMessage("Quantity is required.");

        RuleFor(v => v.ExpiryDate)
            .NotEmpty().WithMessage("ExpiryDate is required.")
            .GreaterThan(DateTime.Now).WithMessage("ExpiryDate must be greater than today.");
        
        RuleFor(v => v.Type)
            .NotEmpty().WithMessage("Type is required.")
            .IsInEnum().WithMessage("Type is invalid.");

        RuleFor(v => v.Value)
            .NotEmpty().WithMessage("Value is required.")
            .GreaterThan(0).WithMessage("Value must be greater than 0.");
        
        RuleForEach(v => v.Products)
            .GreaterThan(0).WithMessage("Product id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.Products.AnyAsync(p => p.Id == id, cancellationToken))
            .When(v => v.Products != null && v.Products.Any());
    }
}
