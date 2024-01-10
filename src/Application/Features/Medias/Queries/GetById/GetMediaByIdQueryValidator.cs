namespace NiceShop.Application.Features.Medias.Queries.GetById;

public class GetMediaByIdQueryValidator : AbstractValidator<GetMediaByIdQuery>
{
    public GetMediaByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
