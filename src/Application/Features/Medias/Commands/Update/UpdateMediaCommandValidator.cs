namespace NiceShop.Application.Features.Medias.Commands.Update;

public class UpdateMediaCommandValidator : AbstractValidator<UpdateMediaCommand>
{
    public UpdateMediaCommandValidator()
    {
        RuleFor(v => v.Id).GreaterThan(0);
        RuleFor(v => v.Alt).MaximumLength(1000).NotEmpty();
    }
}
