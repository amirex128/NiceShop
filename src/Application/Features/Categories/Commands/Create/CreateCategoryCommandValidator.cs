namespace NiceShop.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");
        
        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());
        
        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .When(v => v.Medias != null && v.Medias.Any());
    }
}
