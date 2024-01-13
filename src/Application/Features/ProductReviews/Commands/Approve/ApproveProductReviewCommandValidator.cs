using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.ProductReviews.Commands.Approve;

public class ApproveProductReviewCommandValidator : AbstractValidator<ApproveProductReviewCommand>
{
    public ApproveProductReviewCommandValidator(IApplicationDbContext context)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
