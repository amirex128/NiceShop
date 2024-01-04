namespace NiceShop.Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommandValidator : AbstractValidator<DeleteCouponCommand>
{
    public DeleteCouponCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
    }
}
