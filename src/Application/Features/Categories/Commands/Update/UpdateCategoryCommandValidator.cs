using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Categories.Commands.Update;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(v => v.Name)
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
            .When(v => v.Name != null);

        RuleFor(v => v.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
            .When(v => v.Description != null);

        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());
        
        RuleFor(v => v.Slug)
            .MaximumLength(200).WithMessage("Slug must not exceed 200 characters.")
            .Must((slug) =>
                 context.Categories.Any(a => a.Slug == slug)).WithMessage("Slug does not exist.")
            .When(v => v.Slug != null);
        
        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .Must((id) => context.Medias.Any(m => m.Id == id)).WithMessage("Media id does not exist.")
            .When(v => v.Medias != null && v.Medias.Any());
    }
}
