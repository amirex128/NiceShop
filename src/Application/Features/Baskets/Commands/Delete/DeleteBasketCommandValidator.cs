namespace NiceShop.Application.Features.Baskets.Commands.Delete;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}
