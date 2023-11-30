namespace NiceShop.Application.Features.Addresses.Queries.GetAddressesWithPagination;

public class GetAddressesWithPaginationQueryValidator : AbstractValidator<GetAddressesWithPaginationQuery>
{
    public GetAddressesWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
