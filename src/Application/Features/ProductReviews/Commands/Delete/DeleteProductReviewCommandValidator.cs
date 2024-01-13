namespace NiceShop.Application.Features.ProductReviews.Commands.Delete;

public class DeleteProductReviewCommandValidator : AbstractValidator<DeleteProductReviewCommand>
{
    public DeleteProductReviewCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}
