using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");
        
        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());
        
        RuleFor(v => v.Slug)
            .NotEmpty().WithMessage("Slug is required.")
            .MustAsync(async (slug, cancellationToken) =>
                !await context.Categories.AnyAsync(a => a.Slug == slug, cancellationToken))
            .MaximumLength(200).WithMessage("Slug must not exceed 200 characters.");

        
        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .MustAsync(async (id, cancellationToken) => await context.Medias.AnyAsync(m => m.Id == id, cancellationToken))
            .When(v => v.Medias != null && v.Medias.Any());
    }
}
