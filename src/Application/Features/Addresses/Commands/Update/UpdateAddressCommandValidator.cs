namespace NiceShop.Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 100).WithMessage("Title must be between 2 and 100 characters.")
            .When(x => x.Title != null);
      
        RuleFor(x => x.AddressLine)
            .NotEmpty().WithMessage("AddressLine is required.")
            .Length(5, 200).WithMessage("AddressLine must be between 5 and 200 characters.")
            .When(x => x.AddressLine != null);

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("PostalCode is required.")
            .Matches(@"^\d{5}$").WithMessage("PostalCode must be 5 digits.")
            .When(x => x.PostalCode != null);

        RuleFor(x => x.CityId)
            .GreaterThan(0).WithMessage("CityId must be greater than 0.")
            .When(x => x.CityId.HasValue);
        
        RuleFor(x => x.ProvinceId)
            .GreaterThan(0).WithMessage("ProvinceId must be greater than 0.")
            .When(x => x.ProvinceId.HasValue);
    }
}
