using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductReviews.Commands.Create;

public class CreateProductReviewCommandValidator : AbstractValidator<CreateProductReviewCommand>
{
    public CreateProductReviewCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Rating)
            .NotEmpty().WithMessage("Rating is required")
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5")
            .When(v => v.Rating != null);

        RuleFor(v => v.ReviewText)
            .NotEmpty().WithMessage("ReviewText is required");

        RuleFor(v => v.ProductId)
            .NotEmpty().WithMessage("ProductId is required")
            .GreaterThan(0).WithMessage("ProductId must be greater than 0");
        
    }
}
