namespace NiceShop.Application.Features.Baskets.Queries.GetById;

public class GetBasketByIdQueryValidator : AbstractValidator<GetBasketByIdQuery>
{
    public GetBasketByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}
