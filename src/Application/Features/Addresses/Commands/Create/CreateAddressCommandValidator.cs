namespace NiceShop.Application.Features.Addresses.Commands.Create;

public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
{
    public CreateAddressCommandValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(x => x.AddressLine)
            .NotEmpty().WithMessage("AddressLine is required.")
            .Length(5, 200).WithMessage("AddressLine must be between 5 and 200 characters.");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.")
            .Matches(@"^\d{5}$").WithMessage("PostalCode must be 5 digits.");

        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("CityId is required.")
            .GreaterThan(0).WithMessage("CityId must be greater than 0.");

        RuleFor(x => x.ProvinceId)
            .NotEmpty().WithMessage("ProvinceId is required.")
            .GreaterThan(0).WithMessage("ProvinceId must be greater than 0.");

    }
}
