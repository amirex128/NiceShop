using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductReviews.Commands.Update;

public class UpdateProductReviewCommandValidator : AbstractValidator<UpdateProductReviewCommand>
{
    public UpdateProductReviewCommandValidator()
    {
        RuleFor(v => v.Rating)
            .NotEmpty().WithMessage("Rating is required")
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5")
            .When(v => v.Rating != null);

        RuleFor(v => v.ReviewText)
            .NotEmpty().WithMessage("ReviewText is required")
            .When(v => v.ReviewText != null);
    }
}
