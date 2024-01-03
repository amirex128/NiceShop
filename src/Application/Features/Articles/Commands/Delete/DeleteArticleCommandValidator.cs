namespace NiceShop.Application.Features.Articles.Commands.Delete;

public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
{
    public DeleteArticleCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .GreaterThan(0).WithMessage("Id must be greater than 0");
    }
}
