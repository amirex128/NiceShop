namespace NiceShop.Application.Features.ProductReviews.Queries.GetWithPagination;

public class GetProductReviewsWithPaginationQueryValidator : AbstractValidator<GetProductReviewsWithPaginationQuery>
{
    public GetProductReviewsWithPaginationQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("ProductId is required.")
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
