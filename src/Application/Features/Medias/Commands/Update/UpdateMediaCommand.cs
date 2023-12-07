using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Application.Features.Medias.Commands.Update;

public record UpdateMediaCommand : IRequest<Dictionary<string, object>>
{
    public int Id { get; init; }
    public required string Alt { get; set; }
}

public class UpdateMediaCommandValidator : AbstractValidator<UpdateMediaCommand>
{
    public UpdateMediaCommandValidator()
    {
        RuleFor(v => v.Alt).MaximumLength(1000).NotEmpty();
    }
}

public class UpdateMediaCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateMediaCommand, Dictionary<string, object>>
{
    public async Task<Dictionary<string, object>> Handle(UpdateMediaCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Medias
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Alt = request.Alt;
        await context.SaveChangesAsync(cancellationToken);

        return new Dictionary<string, object>();
    }
}
