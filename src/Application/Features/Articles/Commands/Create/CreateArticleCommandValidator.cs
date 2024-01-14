using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Articles.Commands.Create;

public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(v => v.Description)
            .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

        RuleFor(v => v.Body)
            .NotEmpty().WithMessage("Body is required.");

        RuleFor(v => v.Slug)
            .NotEmpty().WithMessage("Slug is required.")
            .Must((slug) =>
                !context.Articles.Any(a => a.Slug == slug))
            .MaximumLength(200).WithMessage("Slug must not exceed 200 characters.");

        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());

        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .Must((id) => context.Medias.Any(m => m.Id == id))
            .WithMessage("Media id must be valid.")
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .Must((id) => context.Categories.Any(c => c.Id == id))
            .WithMessage("Category id must be valid.")
            .When(v => v.Categories != null && v.Categories.Any());
    }
}
