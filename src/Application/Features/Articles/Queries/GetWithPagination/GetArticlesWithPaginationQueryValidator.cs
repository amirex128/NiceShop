namespace NiceShop.Application.Features.Articles.Queries.GetWithPagination;

public class GetArticlesWithPaginationQueryValidator : AbstractValidator<GetArticlesWithPaginationQuery>
{
    public GetArticlesWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
