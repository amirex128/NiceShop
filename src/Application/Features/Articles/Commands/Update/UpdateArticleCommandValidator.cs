namespace NiceShop.Application.Features.Articles.Commands.Update;

public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
{
    public UpdateArticleCommandValidator()
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
            .When(v => v.Slug != null);
        
        RuleForEach(v => v.Medias)
            .GreaterThan(0).WithMessage("Media id must be greater than 0.")
            .When(v => v.Medias != null && v.Medias.Any());

        RuleForEach(v => v.Categories)
            .GreaterThan(0).WithMessage("Category id must be greater than 0.")
            .When(v => v.Categories != null && v.Categories.Any());
    }
}
