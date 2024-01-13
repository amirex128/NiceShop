using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(v => v.Title)
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .When(v => v.Title != null);

        RuleFor(v => v.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.")
            .When(v => v.Description != null);
        
        RuleFor(v => v.Slug)
            .MaximumLength(200).WithMessage("Slug must not exceed 200 characters.")
            .MustAsync(async (slug, cancellationToken) =>
                !await context.Articles.AnyAsync(a => a.Slug == slug, cancellationToken))
            .When(v => v.Slug != null);
        
        RuleForEach(v => v.SeoTags)
            .MaximumLength(100).WithMessage("SeoTag must not exceed 100 characters.")
            .When(v => v.SeoTags != null && v.SeoTags.Any());

        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .MustAsync(async (id, cancellation) => await context.Medias.AnyAsync(m => m.Id == id, cancellation))
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .MustAsync(async (id, cancellation) => await context.Categories.AnyAsync(c => c.Id == id, cancellation))
            .When(v => v.Categories != null && v.Categories.Any());
    }
}
