namespace NiceShop.Application.Features.Coupons.Commands.Check;

public class CheckCouponCommandValidator : AbstractValidator<CheckCouponCommand>
{
    public CheckCouponCommandValidator()
    {
        RuleFor(v => v.Code)
            .NotEmpty().WithMessage("Code is required.")
            .MaximumLength(250).WithMessage("Code must not exceed 250 characters.");
        
        RuleFor(v => v.BasketId)
            .GreaterThanOrEqualTo(1).WithMessage("BasketId at least greater than or equal to 1.");

    }
}
