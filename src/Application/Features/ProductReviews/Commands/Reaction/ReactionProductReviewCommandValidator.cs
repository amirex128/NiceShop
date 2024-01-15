using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductReviews.Commands.Reaction;

public class CreateProductReviewCommandValidator : AbstractValidator<ReactionProductReviewCommand>
{
    public CreateProductReviewCommandValidator(IApplicationDbContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        
        RuleFor(x => x.ReactionPositive)
            .NotEmpty().WithMessage("ReactionPositive is required");
    }
}
