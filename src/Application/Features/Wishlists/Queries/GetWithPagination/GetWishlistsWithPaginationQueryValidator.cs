namespace NiceShop.Application.Features.Wishlists.Queries.GetWithPagination;

public class GetWishlistsWithPaginationQueryValidator : AbstractValidator<GetWishlistsWithPaginationQuery>
{
    public GetWishlistsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
