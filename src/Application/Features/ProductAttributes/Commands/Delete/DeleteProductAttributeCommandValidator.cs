namespace NiceShop.Application.Features.ProductAttributes.Commands.Delete;

public class DeleteProductAttributeCommandValidator : AbstractValidator<DeleteProductAttributeCommand>
{
    public DeleteProductAttributeCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}
