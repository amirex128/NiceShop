namespace NiceShop.Application.Features.Medias.Commands.Delete;

public class DeleteMediaCommandValidator : AbstractValidator<DeleteMediaCommand>
{
    public DeleteMediaCommandValidator()
    {
        RuleFor(v => v.Id).GreaterThan(0);
    }
}
