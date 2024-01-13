using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Coupons.Commands.Update;

public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>
{
    public UpdateCouponCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Code is required.")
            .MaximumLength(200).WithMessage("Code must not exceed 200 characters.")
            .When(v => v.Code != null);
        
        RuleFor(v => v.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.")
            .When(v => v.Quantity.HasValue);

        RuleFor(v => v.ExpiryDate)
            .NotEmpty().WithMessage("ExpiryDate is required.")
            .GreaterThan(DateTime.Now).WithMessage("ExpiryDate must be in the future.")
            .When(v => v.ExpiryDate.HasValue);

        RuleFor(v => v.Type)
            .IsInEnum().WithMessage("Invalid Type.")
            .When(v => v.Type.HasValue);

        RuleFor(v => v.Value)
            .GreaterThanOrEqualTo(0).WithMessage("Value must be greater than or equal to 0.")
            .When(v => v.Value.HasValue && v.Value > 0);

        RuleForEach(v => v.Products)
            .GreaterThan(0).WithMessage("Product id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.Products.AnyAsync(p => p.Id == id, cancellationToken))
            .When(v => v.Products != null && v.Products.Any());
    }
}
