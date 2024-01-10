namespace NiceShop.Application.Features.Medias.Commands.Create;

public class CreateMediaCommandValidator : AbstractValidator<CreateMediaCommand>
{
    public CreateMediaCommandValidator()
    {
        RuleFor(v => v.Alt).MaximumLength(1000);
    }
}
